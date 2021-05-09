using System;
using Facebook;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Common.Dtos;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Core.Interfaces.Handlers;
using Pinf.InstaService.DAL.Pinfluencer.Common;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Influencer = Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble.Influencer;
using InfluencerModel = Pinf.InstaService.Core.Models.User.Influencer;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    //TODO: REFACTOR SEPERATE DATA SOURCES INTO SEPERATE REPOSITORIES
    //TODO: ADD LOGGING !!!
    public class UserRepository : IUserRepository
    {
        private readonly Auth0Context _auth0Context;
        private readonly FacebookContext _facebookContext;
        private readonly IBubbleDataHandler<UserRepository> _bubbleDataHandler;
        private readonly IUser _user;
        private readonly ILoggerAdapter<UserRepository> _logger;

        public UserRepository( Auth0Context auth0Context,
            FacebookContext facebookContext,
            IUser user,
            ILoggerAdapter<UserRepository> logger,
            IBubbleDataHandler<UserRepository> bubbleDataHandler )
        {
            _auth0Context = auth0Context;
            _facebookContext = facebookContext;
            _user = user;
            _logger = logger;
            _bubbleDataHandler = bubbleDataHandler;
        }

        //TODO: dont swallow all exceptions
        public OperationResult<string> GetInstagramToken( string id )
        {
            try
            {
                var user = _auth0Context.GetUser( id );
                var result =
                    new OperationResult<string>( user.Identities[ 0 ].AccessToken, OperationResultEnum.Success );
                _logger.LogInfo( "instagram token fetched successfully" );
                return result;
            }
            catch( Exception )
            {
                _logger.LogError( "instagram token was not fetched" );
                return new OperationResult<string>( "", OperationResultEnum.Failed );
            }
        }

        public OperationResultEnum CreateInfluencer( InfluencerModel influencer ) =>
            _bubbleDataHandler.Create( "influencer", influencer, MapToInfluencerDto );

        public Influencer MapToInfluencerDto( InfluencerModel influencer ) => 
            new Influencer
            {
                Age = influencer.Age,
                Bio = influencer.Bio,
                Gender = influencer.Gender,
                Instagram = influencer.InstagramHandle,
                Location = influencer.Location,
                Profile = influencer.User.Id
            };

        //TODO: WRITE TESTS FOR SERIALIZATION AND SCHEMA ISSUES ( REGRESSION )
        public OperationResult<IUser> Get( string id )
        {
            try
            {
                var facebookUserStr = _facebookContext
                    .Get( "me", new RequestFields { fields = "birthday,location,gender" } );
                var facebookUser = JsonConvert.DeserializeObject<FacebookUser>( facebookUserStr );
                return _bubbleDataHandler.Read<IUser,TypeResponse<Profile>>( $"profile/{id}", x =>
                {
                    _user.Id = x.Type.Id;
                    _user.Name = x.Type.Name;
                    _user.Birthday = facebookUser.Birthday;
                    _user.Gender = facebookUser.Gender;
                    _user.Location = facebookUser.Location == null ? "Unknown" : facebookUser.Location.Name;
                    return _user;
                }, _user );
            }
            catch( FacebookApiException e ) when( e is FacebookApiException || e is FacebookApiLimitException || e is FacebookOAuthException )
            {
                _logger.LogError( "user was not fetched" );
                return new OperationResult<IUser>( _user, OperationResultEnum.Failed );
            }
        }
    }
}
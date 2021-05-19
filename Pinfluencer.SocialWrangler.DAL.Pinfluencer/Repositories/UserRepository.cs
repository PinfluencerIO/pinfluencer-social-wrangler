using System;
using Facebook;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using Influencer = Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble.Influencer;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    //TODO: REFACTOR SEPERATE DATA SOURCES INTO SEPERATE REPOSITORIES
    //TODO: ADD LOGGING !!!
    public class UserRepository : IUserRepository
    {
        private readonly Auth0Context _auth0Context;
        private readonly FacebookContext _facebookContext;
        private readonly IBubbleDataHandler<UserRepository> _bubbleDataHandler;
        private readonly ILoggerAdapter<UserRepository> _logger;

        public UserRepository( Auth0Context auth0Context,
            FacebookContext facebookContext,
            ILoggerAdapter<UserRepository> logger,
            IBubbleDataHandler<UserRepository> bubbleDataHandler )
        {
            _auth0Context = auth0Context;
            _facebookContext = facebookContext;
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

        public Dtos.Bubble.Influencer MapToInfluencerDto( InfluencerModel influencer ) => 
            new Dtos.Bubble.Influencer
            {
                Age = influencer.Age,
                Bio = influencer.Bio,
                Gender = influencer.Gender,
                Instagram = influencer.InstagramHandle,
                Location = influencer.Location,
                Profile = influencer.User.Id
            };

        //TODO: WRITE TESTS FOR SERIALIZATION AND SCHEMA ISSUES ( REGRESSION )
        public OperationResult<User> Get( string id )
        {
            try
            {
                var facebookUserStr = _facebookContext
                    .Get( "me", new RequestFields { fields = "birthday,location,gender" } );
                var facebookUser = JsonConvert.DeserializeObject<FacebookUser>( facebookUserStr );
                return _bubbleDataHandler.Read<User,TypeResponse<Profile>>( $"profile/{id}", x =>
                    new User( )
                    {
                        Id = x.Type.Id,
                        Name = x.Type.Name
                    }, new User() );
            }
            catch( FacebookApiException e ) when( e is FacebookApiException || e is FacebookApiLimitException || e is FacebookOAuthException )
            {
                _logger.LogError( "user was not fetched" );
                return new OperationResult<User>( new User(), OperationResultEnum.Failed );
            }
        }
    }
}
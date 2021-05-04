using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using Facebook;
using Newtonsoft.Json;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Common.Dtos;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Influencer = Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble.Influencer;
using InfluencerModel = Pinf.InstaService.Core.Models.User.Influencer;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    //TODO: ADD LOGGING !!!
    public class UserRepository : BubbleRepository<UserRepository>, IUserRepository
    {
        private readonly Auth0Context _auth0Context;
        private readonly FacebookContext _facebookContext;
        private readonly IUser _user;
        protected override string Resource => "user";

        public UserRepository( Auth0Context auth0Context,
            IBubbleClient bubbleClient,
            FacebookContext facebookContext,
            IUser user,
            ILoggerAdapter<UserRepository> logger ) : base( bubbleClient, logger )
        {
            _auth0Context = auth0Context;
            _facebookContext = facebookContext;
            _user = user;
        }

        //TODO: dont swallow all exceptions
        public OperationResult<string> GetInstagramToken( string id )
        {
            try
            {
                var user = _auth0Context.GetUser( id );
                var result =
                    new OperationResult<string>( user.Identities[ 0 ].AccessToken, OperationResultEnum.Success );
                Logger.LogInfo( "instagram token fetched successfully" );
                return result;
            }
            catch( Exception )
            {
                Logger.LogError( "instagram token was not fetched" );
                return new OperationResult<string>( "", OperationResultEnum.Failed );
            }
        }

        public OperationResultEnum CreateInfluencer( InfluencerModel influencer ) =>
            CreateRequest( ( ) => BubbleClient.Post( "influencer",
                new Influencer
                {
                    Age = influencer.Age,
                    Bio = influencer.Bio,
                    Gender = influencer.Gender,
                    Location = influencer.Location,
                    Instagram = influencer.InstagramHandle,
                    Profile = influencer.User.Id
                } ) );

            //TODO: WRITE TESTS FOR SERIALIZATION AND SCHEMA ISSUES ( REGRESSION )
        public OperationResult<IUser> Get( string id )
        {
            try
            {
                var facebookUserStr = _facebookContext
                    .Get( "me", new RequestFields { fields = "birthday,location,gender" } );
                var facebookUser = JsonConvert.DeserializeObject<FacebookUser>( facebookUserStr );
                var (validRequest, (httpStatusCode, typeResponse)) =
                    ValidateRequestException( ( ) => BubbleClient.Get<TypeResponse<Profile>>( $"profile/{id}" ) );
                if( validRequest )
                    if( ValidateHttpCode( httpStatusCode ) )
                    {
                        _user.Id = typeResponse.Type.Id;
                        _user.Name = typeResponse.Type.Name;
                        _user.Birthday = facebookUser.Birthday;
                        _user.Gender = facebookUser.Gender;
                        _user.Location = facebookUser.Location == null ? "Unknown" : facebookUser.Location.Name;
                        Logger.LogInfo( "user was fetched successfully" );
                        return new OperationResult<IUser>( _user, OperationResultEnum.Success );
                    }
            }
            catch( FacebookApiException e ) when( e is FacebookApiException || e is FacebookApiLimitException || e is FacebookOAuthException )
            {
            }
            Logger.LogError( "user was not fetched" );
            return new OperationResult<IUser>( _user, OperationResultEnum.Failed );
        }
    }
}
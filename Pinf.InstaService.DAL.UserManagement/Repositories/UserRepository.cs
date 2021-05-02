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
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Influencer = Pinf.InstaService.DAL.UserManagement.Dtos.Bubble.Influencer;
using InfluencerModel = Pinf.InstaService.Core.Models.User.Influencer;

namespace Pinf.InstaService.DAL.UserManagement.Repositories
{
    //TODO: ADD LOGGING !!!
    public class UserRepository : IUserRepository
    {
        private readonly Auth0Context _auth0Context;
        private readonly IBubbleClient _bubbleClient;
        private readonly FacebookContext _facebookContext;
        private readonly IUser _user;
        private readonly ILoggerAdapter<UserRepository> _logger;

        public UserRepository( Auth0Context auth0Context,
            IBubbleClient bubbleClient,
            FacebookContext facebookContext,
            IUser user,
            ILoggerAdapter<UserRepository> logger )
        {
            _auth0Context = auth0Context;
            _bubbleClient = bubbleClient;
            _facebookContext = facebookContext;
            _user = user;
            _logger = logger;
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

        public OperationResultEnum CreateInfluencer( InfluencerModel influencer )
        {
            var (validRequest, httpStatusCode) = validateRequestException( ( ) => _bubbleClient.Post( "influencer",
                new Influencer
                {
                    Age = influencer.Age,
                    Bio = influencer.Bio,
                    Gender = influencer.Gender,
                    Location = influencer.Location,
                    Instagram = influencer.InstagramHandle,
                    Profile = influencer.User.Id
                } ) );
            if( validRequest & validateHttpCode( httpStatusCode ) )
            {
                _logger.LogInfo( "influencer created successfully" );
                return OperationResultEnum.Success;
            }
            _logger.LogError( "influencer was not created" );
            return OperationResultEnum.Failed;
        }

        //TODO: WRITE TESTS FOR SERIALIZATION AND SCHEMA ISSUES ( REGRESSION )
        public OperationResult<IUser> Get( string id )
        {
            try
            {
                var facebookUserStr = _facebookContext
                    .Get( "me", new RequestFields { fields = "birthday,location,gender" } );
                var facebookUser = JsonConvert.DeserializeObject<FacebookUser>( facebookUserStr );
                var (validRequest, (httpStatusCode, typeResponse)) =
                    validateRequestException( ( ) => _bubbleClient.Get<TypeResponse<Profile>>( $"profile/{id}" ) );
                if( validRequest )
                    if( validateHttpCode( httpStatusCode ) )
                    {
                        _user.Id = typeResponse.Type.Id;
                        _user.Name = typeResponse.Type.Name;
                        _user.Birthday = facebookUser.Birthday;
                        _user.Gender = facebookUser.Gender;
                        _user.Location = facebookUser.Location.Name;
                        _logger.LogInfo( "user was fetched successfully" );
                        return new OperationResult<IUser>( _user, OperationResultEnum.Success );
                    }
            }
            catch( FacebookApiException e ) when( e is FacebookApiException || e is FacebookApiLimitException || e is FacebookOAuthException )
            {
            }
            _logger.LogError( "user was not fetched" );
            return new OperationResult<IUser>( _user, OperationResultEnum.Failed );
        }

        private bool validateHttpCode( HttpStatusCode code ) { return code.GetHashCode( ).ToString( )[0].ToString() == "2"; }

        private( bool, T ) validateRequestException<T>( Func<T> httpFunc )
        {
            try { return( true, httpFunc( ) ); }
            catch( Exception e ) when( e is ArgumentException || e is HttpRequestException )
            {
                return( false, default );
            }
        }
    }
}
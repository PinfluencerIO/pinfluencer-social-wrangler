using System;
using System.Net;
using System.Net.Http;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;
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

        public UserRepository( Auth0Context auth0Context, IBubbleClient bubbleClient )
        {
            _auth0Context = auth0Context;
            _bubbleClient = bubbleClient;
        }

        //TODO: dont swallow all exceptions
        public OperationResult<string> GetInstagramToken( string id )
        {
            try
            {
                var user = _auth0Context.GetUser( id );
                return new OperationResult<string>( user.Identities[ 0 ].AccessToken, OperationResultEnum.Success );
            }
            catch( Exception ) { return new OperationResult<string>( "", OperationResultEnum.Failed ); }
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
            if( validRequest & validateHttpCode( httpStatusCode ) ) return OperationResultEnum.Success;
            return OperationResultEnum.Failed;
        }

        public OperationResult<User> Get( string id )
        {
            var (validRequest, (httpStatusCode, typeResponse)) =
                validateRequestException( ( ) => _bubbleClient.Get<TypeResponse<Profile>>( $"profile/{id}" ) );
            if( validRequest )
                if( validateHttpCode( httpStatusCode ) )
                    return new OperationResult<User>(
                        new User { Id = typeResponse.Type.Id, Name = typeResponse.Type.Name },
                        OperationResultEnum.Success );
            return new OperationResult<User>( new User( ), OperationResultEnum.Failed );
        }

        private bool validateHttpCode( HttpStatusCode code ) { return code == HttpStatusCode.OK; }

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
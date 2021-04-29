using System;
using System.Net;
using System.Net.Http;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
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
            return OperationResultEnum.Failed;
        }

        public OperationResult<User> Get( string id )
        {
            var ( validRequest,
                result ) = validateBubbleRequest<TypeResponse<Profile>>( _bubbleClient
                    .Get<TypeResponse<Profile>>, $"profile/{id}" );
            if( validRequest )
            {
                return new OperationResult<User>( new User { Id = result.Item2.Type.Id, Name = result.Item2.Type.Name },
                    OperationResultEnum.Success );
            }
            return new OperationResult<User>( new User( ), OperationResultEnum.Failed );
        }
        
        private ( bool, ( HttpStatusCode, T ) ) validateBubbleRequest<T>( Func<string, ( HttpStatusCode, T )> httpFunc, string uri ) where T : class
        {
            try
            {
                var ( httpStatusCode, typeResponse ) = httpFunc( uri );
                var returnVal = ( httpStatusCode, typeResponse );
                if( httpStatusCode != HttpStatusCode.OK )
                {
                    return ( false, returnVal );
                }
                return ( true, returnVal );
            }
            catch( Exception e ) when( e is ArgumentException || e is HttpRequestException )
            {
                return( false, ( HttpStatusCode.BadRequest, null ) );
            }
        }
    }
}
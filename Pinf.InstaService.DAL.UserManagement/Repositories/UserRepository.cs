using System;
using System.Net;
using System.Net.Http;
using AutoMapper;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Dtos;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Crosscutting.Web;
using Pinf.InstaService.DAL.UserManagement.Dtos;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Profile = Pinf.InstaService.DAL.UserManagement.Dtos.Bubble.Profile;

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

        public OperationResultEnum CreateInfluencer( InfluencerProfile id ) { throw new NotImplementedException( ); }

        public OperationResult<User> Get( string id )
        {
            try
            {
                var (httpStatusCode, typeResponse) = _bubbleClient.Get<TypeResponse<Profile>>( $"profile/{id}" );
                if( httpStatusCode != HttpStatusCode.OK )
                {
                    return new OperationResult<User>( new User( ), OperationResultEnum.Failed );
                }

                var profile = typeResponse.Type;
                return new OperationResult<User>( new User { Id = profile.Id, Name = profile.Name },
                    OperationResultEnum.Success );
            }
            catch( Exception e ) when( e is ArgumentException || e is HttpRequestException )
            {
                return new OperationResult<User>( new User( ), OperationResultEnum.Failed );
            }
        }
    }
}
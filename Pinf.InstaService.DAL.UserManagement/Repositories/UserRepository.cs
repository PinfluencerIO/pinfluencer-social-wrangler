using System;
using System.Net;
using System.Net.Http;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Common.Dtos;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Pinf.InstaService.DAL.UserManagement.Dtos.Facebook;
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

        public UserRepository( Auth0Context auth0Context, IBubbleClient bubbleClient, FacebookContext facebookContext, IUser user )
        {
            _auth0Context = auth0Context;
            _bubbleClient = bubbleClient;
            _facebookContext = facebookContext;
            _user = user;
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

        public OperationResult<IUser> Get( string id )
        {
            var facebookUser = _facebookContext
                .FacebookClient
                .Get<FacebookUser>( "me", new RequestFields{ fields = "birthday,location,gender" } );
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
                    return new OperationResult<IUser>( _user, OperationResultEnum.Success );
                }

            return new OperationResult<IUser>( _user, OperationResultEnum.Failed );
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
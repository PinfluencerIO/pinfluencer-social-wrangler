using System;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;

namespace Pinf.InstaService.DAL.UserManagement.Repositories
{
    public class Auth0BubbleUserRepository : IUserRepository
    {
        private readonly Auth0Context _auth0Context;

        public Auth0BubbleUserRepository( Auth0Context auth0Context ) { _auth0Context = auth0Context; }

        public OperationResult<string> GetInstagramToken( string id )
        {
            try
            {
                var user = _auth0Context.GetUser( id );
                return new OperationResult<string>( user.Identities[ 0 ].AccessToken, OperationResultEnum.Success );
            }
            catch( Exception ) { return new OperationResult<string>( "", OperationResultEnum.Failed ); }
        }

        public OperationResultEnum Create( string id ) { throw new NotImplementedException( ); }
    }
}
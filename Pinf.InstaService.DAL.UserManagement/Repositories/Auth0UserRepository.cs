using System;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.Core.Repositories;

namespace Pinf.InstaService.DAL.UserManagement.Repositories
{
    public class Auth0UserRepository : IUserRepository
    {
        private readonly Auth0Context _auth0Context;

        public Auth0UserRepository( Auth0Context auth0Context ) { _auth0Context = auth0Context; }

        public OperationResult<string> GetInstagramToken( string id )
        {
            try
            {
                var user = _auth0Context.GetUser( id );
                return new OperationResult<string>( user.Identities[ 0 ].AccessToken, OperationResultEnum.Success );
            }
            catch( Exception ) { return new OperationResult<string>( "", OperationResultEnum.Failed ); }
        }
    }
}
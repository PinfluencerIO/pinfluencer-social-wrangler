using Bootstrapping.Services;
using Bootstrapping.Services.Repositories;

namespace DAL.UserManagement.Repositories
{
    public class Auth0UserRepository : IUserRepository
    {
        private readonly Auth0Context _auth0Context;

        public Auth0UserRepository(Auth0Context auth0Context)
        {
            _auth0Context = auth0Context;
        }

        public OperationResult<string> GetInstagramToken(string id)
        {
            _auth0Context.GetUser(id);
            return null;
        }
    }
}
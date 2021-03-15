using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace DAL.UserManagement
{
    public class Auth0Context
    {
        private readonly ManagementApiClient _managementApiClient;

        public Auth0Context(ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }

        public User GetUser(string id)
        {
            return _managementApiClient.Users.GetAsync(id).Result;
        }
    }
}
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace Pinf.InstaService.DAL.Pinfluencer
{
    public class Auth0Context
    {
        public ManagementApiClient ManagementApiClient { set; get; }

        public User GetUser( string id ) { return ManagementApiClient.Users.GetAsync( id ).Result; }
    }
}
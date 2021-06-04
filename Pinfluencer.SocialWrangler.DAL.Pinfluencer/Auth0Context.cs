using System.Linq;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer
{
    public class Auth0Context
    {
        public ManagementApiClient ManagementApiClient { set; get; }

        public string GetIdentityToken( string id ) 
        { 
            return ManagementApiClient
                .Users
                .GetAsync( id )
                .Result
                .Identities
                .First( )
                .AccessToken; 
        }
    }
}
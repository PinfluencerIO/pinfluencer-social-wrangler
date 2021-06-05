using System.Linq;
using Auth0.ManagementApi;
using Microsoft.Extensions.Configuration;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer
{
    public class Auth0ManagementClientDecorator : IAuthServiceManagementClientDecorator
    {
        private readonly AuthServiceOptions _auth0Settings;
        private ManagementApiClient _managementApiClient;
        
        public Auth0ManagementClientDecorator( IConfiguration configuration )
        {
            _auth0Settings = configuration
                .Get<AppOptions>( )
                .AuthService;
        }

        public string Secret
        {
            set => _managementApiClient = new ManagementApiClient( value,
                _auth0Settings.Domain,
                new HttpClientManagementConnection( ) );
        }

        public string GetIdentityToken( string id )
        {
            return _managementApiClient
                .Users
                .GetAsync( id )
                .Result
                .Identities
                .First( )
                .AccessToken;
        }
    }
}
using Auth0.Core.Exceptions;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Managers
{
    public class Auth0AuthManager : IAuthServiceAuthManager
    {
        private readonly IConfigurationAdapter _configuration;
        private readonly IAuthServiceAuthenticationClientDecoratorFactory _authenticationClientFactory;
        private readonly IAuthServiceManagementClientDecorator _auth0ManagementClientDecorator;

        public Auth0AuthManager( IConfigurationAdapter configuration, IAuthServiceAuthenticationClientDecoratorFactory authenticationClientFactory, IAuthServiceManagementClientDecorator auth0ManagementClientDecorator )
        {
            _configuration = configuration;
            _authenticationClientFactory = authenticationClientFactory;
            _auth0ManagementClientDecorator = auth0ManagementClientDecorator;
        }

        public Result Initialize( )
        {
            var auth0Settings = _configuration.Get<AppOptions>( ).AuthService;

            if( auth0Settings.Domain == "" || auth0Settings.Id == "" || auth0Settings.Secret == "" ||
                auth0Settings.ManagementDomain == "" ||
                auth0Settings.Domain == null || auth0Settings.Id == null || auth0Settings.Secret == null ||
                auth0Settings.ManagementDomain == null )
            {
                return Result.Error( "auth0 configuration settings are not valid" );
            }

            var authenticationApiClient = _authenticationClientFactory.Factory( auth0Settings.Domain );

            try
            {
                var token = authenticationApiClient.GetToken( ( auth0Settings.Id,
                    auth0Settings.Secret,
                    auth0Settings.ManagementDomain ) );

                _auth0ManagementClientDecorator.Secret = token;
            }
            catch( ApiException exception )
            {
                return Result.Error( exception.Message );
            }
            return Result.Success( );
        }
    }
}
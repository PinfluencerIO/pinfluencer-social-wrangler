using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pinf.InstaService.API.InstaFetcher.Options;
using Pinf.InstaService.DAL.UserManagement;

namespace Pinf.InstaService.API.InstaFetcher.Filters
{
    //TODO: factories!!
    //TODO: persist token to file
    //TODO: use transient auth0 context for thread safety, refresh token if expired
    //TODO: validate scopes
    //TODO: middleware should just deal with persisting things to files and validating incoming request!!!!
    public class Auth0Attribute : ActionFilterAttribute, IActionFilter
    {
        private readonly Auth0Context _auth0Context;
        private readonly IConfiguration _configuration;
        private readonly IManagementConnection _managementConnection;
        private readonly IAuthenticationConnection _authenticationConnection;

        public Auth0Attribute( Auth0Context auth0Context,
            IConfiguration configuration,
            IManagementConnection managementConnection,
            IAuthenticationConnection authenticationConnection )
        {
            _auth0Context = auth0Context;
            _configuration = configuration;
            _managementConnection = managementConnection;
            _authenticationConnection = authenticationConnection;
        }

        public async Task Invoke( )
        {
            var auth0Settings = ( ( AppOptions )_configuration.Get( typeof( AppOptions ) ) ).Auth0;

            if( auth0Settings.Domain == null || auth0Settings.Id == null || auth0Settings.Secret == null || auth0Settings.ManagementDomain == null )
            {
                //await HandleError( context, "auth0 configuration settings are not valid" );
            }

            var authenticationApiClient = new AuthenticationApiClient( auth0Settings.Domain, _authenticationConnection );

            try
            {
                var token = await authenticationApiClient.GetTokenAsync( new ClientCredentialsTokenRequest
                {
                    ClientId = auth0Settings.Id,
                    ClientSecret = auth0Settings.Secret,
                    Audience = auth0Settings.ManagementDomain
                } );

                _auth0Context.ManagementApiClient =
                    new ManagementApiClient( token.AccessToken, auth0Settings.Domain, _managementConnection );
            }
            catch( ApiException exception )
            {
                //await HandleError( context, exception.Message );
            }
        }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            
        }
    }
}
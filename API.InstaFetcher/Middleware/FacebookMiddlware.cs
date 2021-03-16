using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Bootstrapping.Services.Repositories;
using DAL.Instagram;
using DAL.UserManagement;
using Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace API.InstaFetcher.Middleware
{
    //TODO: add factories
    public class FacebookMiddlware
    {
        private RequestDelegate _next;

        public FacebookMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            IUserRepository userRepository,
            Auth0Context auth0Context,
            FacebookContext facebookContext,
            IConfiguration configuration,
            IManagementConnection managementConnection
        )
        {
            var auth0Settings = configuration.GetSection("Auth0");
            var clientId = auth0Settings.GetValue<string>("Id");
            var clientSecret = auth0Settings.GetValue<string>("Secret");
            var domain = auth0Settings.GetValue<string>("Domain");
            var audience = auth0Settings.GetValue<string>("ManagementDomain");

            var authenticationApiClient = new AuthenticationApiClient(domain);
            
            var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                Audience = audience
            });

            auth0Context.ManagementApiClient = new ManagementApiClient(token.AccessToken, domain, managementConnection);
            var auth0Id = context.Request.Query["auth0_token"]; 
            facebookContext.FacebookClient = new FacebookClient(userRepository.GetInstagramToken(auth0Id).Value);
            
            await _next.Invoke(context);
        }
    }
}
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Bootstrapping.Services.Repositories;
using DAL.Instagram;
using DAL.UserManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.InstaFetcher.Middleware
{
    //TODO: persist token to file
    //TODO: use singleton auth0 context, refresh token if expired
    public class Auth0Middlware
    {
        private RequestDelegate _next;

        public Auth0Middlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            [FromServices] Auth0Context auth0Context,
            [FromServices] IConfiguration configuration,
            [FromServices] IManagementConnection managementConnection
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

            await _next.Invoke(context);
        }
    }
}
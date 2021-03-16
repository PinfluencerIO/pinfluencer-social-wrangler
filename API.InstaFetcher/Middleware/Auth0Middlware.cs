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
using Newtonsoft.Json;

namespace API.InstaFetcher.Middleware
{
    //TODO: factories!!
    //TODO: persist token to file
    //TODO: use transient auth0 context for thread safety, refresh token if expired
    //TODO: validate scopes
    //TODO: middleware should just deal with persisting things to files and validating incoming request!!!!
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
            [FromServices] IManagementConnection managementConnection,
            [FromServices] IAuthenticationConnection authenticationConnection
        )
        {
            var auth0Settings = configuration.GetSection("Auth0");
            var clientId = auth0Settings["Id"];
            var clientSecret = auth0Settings["Secret"];
            var domain = auth0Settings["Domain"];
            var audience = auth0Settings["ManagementDomain"];

            if (domain == null || clientId == null || clientSecret == null || audience == null)
            {
                await HandleError(context, "auth0 configuration settings are not valid");
            }
            
            var authenticationApiClient = new AuthenticationApiClient(domain,authenticationConnection);
            
            var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                Audience = audience
            });

            auth0Context.ManagementApiClient = new ManagementApiClient(token.AccessToken, domain, managementConnection);

            await _next.Invoke(context);
        }
        
        private static async Task HandleError(HttpContext context, string message)
        {
            context
                .Response
                .StatusCode = 401;
            context
                .Response
                .ContentType = "application/json";
            await context
                .Response
                .WriteAsync(JsonConvert.SerializeObject(new { error = "auth0 authorization error", message }));
        }
    }
}
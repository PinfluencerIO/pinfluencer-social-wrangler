using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Factories;
using Bootstrapping.Services.Repositories;
using DAL.Instagram;
using DAL.Instagram.Dtos;
using DAL.UserManagement;
using Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace API.InstaFetcher.Middleware
{
    //TODO: add factories
    //TODO: validate scopes etc...
    //TODO: create generic error handler
    public class FacebookMiddlware
    {
        private RequestDelegate _next;

        public FacebookMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            [FromServices] IUserRepository userRepository,
            [FromServices] FacebookContext facebookContext,
            [FromServices] IFacebookClientFactory facebookClientFactory
        )
        {
            var auth0Id = context.Request.Query["auth0_id"].ToString();

            if (auth0Id==string.Empty)
            {
                await HandleError(context);
            }

            var tokenResult = userRepository.GetInstagramToken(auth0Id);

            if (tokenResult.Status==OperationResultEnum.Failed)
            {
                await HandleError(context);
            }
            
            facebookContext.FacebookClient = facebookClientFactory.Get(tokenResult.Value);
            
            try
            {
                facebookContext.FacebookClient.Get("debug_token",
                    new RequestDebugTokenParams{input_token = tokenResult.Value});
                await _next.Invoke(context);
            }
            catch (Exception)
            {
                await HandleError(context);
            }
        }

        private static async Task HandleError(HttpContext context)
        {
            context
                .Response
                .StatusCode = 401;
            context
                .Response
                .ContentType = "application/json";
            await context
                .Response
                .WriteAsync(JsonConvert.SerializeObject(new { error = "facebook token error" }));
        }
    }
}
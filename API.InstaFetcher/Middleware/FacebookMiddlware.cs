﻿using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
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
            var auth0Id = context.Request.Query["auth0_id"];
            facebookContext.FacebookClient = facebookClientFactory.Get(userRepository.GetInstagramToken(auth0Id).Value);
            try
            {
                facebookContext.FacebookClient.Get("debug_token",
                    new RequestDebugTokenParams{input_token = facebookContext.FacebookClient.AccessToken});
                await _next.Invoke(context);
            }
            catch (Exception)
            {
                context
                    .Response
                    .StatusCode = 401;
                context
                    .Response
                    .ContentType = "application/json";
                await context
                    .Response
                    .WriteAsync(JsonConvert.SerializeObject(new { error = "facebook token is invalid" }));
            }
        }
    }
}
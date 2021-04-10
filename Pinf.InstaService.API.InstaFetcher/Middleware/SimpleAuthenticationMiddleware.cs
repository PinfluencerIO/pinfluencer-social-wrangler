using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Pinf.InstaService.API.InstaFetcher.Middleware
{
    public class SimpleAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            [FromServices] IConfiguration configuration
        )
        {
            StringValues header;
            var isHeaderPresent = context.Request.Headers.TryGetValue("Simple-Auth-Key", out header);
            if (!isHeaderPresent)
                await HandleError(context, "no 'Simple-Auth-Key' value was present in the request header");

            var key = configuration["Simple-Auth-Key"];

            if (key == null) throw new ArgumentException("config is null");

            if (header.ToString().Equals(key)) await _next.Invoke(context);
            await HandleError(context, "'Simple-Auth-Key' value was not valid");
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
                .WriteAsync(JsonConvert.SerializeObject(new {error = "authorization error", message}));
        }
    }
}
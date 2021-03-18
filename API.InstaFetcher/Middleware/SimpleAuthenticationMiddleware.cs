using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace API.InstaFetcher.Middleware
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
            var isHeaderPresent = context.Request.Headers.TryGetValue("InstaServiceKey", out header);
            if (!isHeaderPresent)
                await HandleError(context, "no 'InstaServiceKey' value was present in the request header");

            var key = configuration["SimpleAuthKey"];

            if (header.ToString().Equals(key)) await _next.Invoke(context);
            await HandleError(context, "'InstaServiceKey' value was not valid");
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;

namespace Pinf.InstaService.API.InstaFetcher.Filters
{
    public class SimpleAuthActionFilter : ActionFilterAttribute
    {
        private const string SimpleKeyName = "Simple-Auth-Key";
        private readonly IConfiguration _configuration;

        public SimpleAuthActionFilter( IConfiguration configuration ) { _configuration = configuration; }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            var confKey = _configuration[ "Simple-Auth-Key" ];
            var isHeaderKeyPresent =
                context.HttpContext.Request.Headers.TryGetValue( SimpleKeyName, out var headerKey );
            if( confKey == null )
                context.Result = new UnauthorizedObjectResult( new ErrorDto
                    { ErrorMsg = "api key is not present in server" } );
            else if( !isHeaderKeyPresent )
                context.Result = new UnauthorizedObjectResult( new ErrorDto
                    { ErrorMsg = "api key was not received" } );
            else if( confKey != headerKey )
                context.Result = new UnauthorizedObjectResult( new ErrorDto
                    { ErrorMsg = "api keys do not match" } );
        }
    }
}
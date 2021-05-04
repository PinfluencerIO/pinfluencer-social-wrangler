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
        private readonly MvcAdapter _mvcAdapter;

        public SimpleAuthActionFilter( IConfiguration configuration, MvcAdapter mvcAdapter )
        {
            _configuration = configuration;
            _mvcAdapter = mvcAdapter;
        }

        public override void OnActionExecuting( ActionExecutingContext context )
        {
            var confKey = _configuration[ "Simple-Auth-Key" ];
            var isHeaderKeyPresent = context.HttpContext.Request.Headers.TryGetValue( SimpleKeyName, out var headerKey );
            if( confKey == null ) context.Result = _mvcAdapter.UnauthorizedError( "api key is not present in server" );
            else if( !isHeaderKeyPresent ) context.Result = _mvcAdapter.UnauthorizedError( "api key was not received" );
            else if( confKey != headerKey ) context.Result = _mvcAdapter.UnauthorizedError( "api keys do not match" );
        }
    }
}
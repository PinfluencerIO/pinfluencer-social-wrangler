using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;


namespace Pinf.InstaService.API.InstaFetcher.Filters
{
    public class SimpleAuth : ActionFilterAttribute, IActionFilter
    {
        private readonly IConfiguration _configuration;

        public SimpleAuth( IConfiguration configuration ) { _configuration = configuration; }

        public override void OnActionExecuted( ActionExecutedContext context )
        {
            //TODO: Not implemented
        }
    }
}
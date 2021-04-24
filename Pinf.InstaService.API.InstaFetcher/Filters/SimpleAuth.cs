using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pinf.InstaService.API.InstaFetcher.Filters
{
    public class SimpleAuth : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted( ActionExecutedContext context )
        {
            throw new NotImplementedException( );
        }
    }
}
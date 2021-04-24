using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using NSubstitute;

namespace Pinf.InstaService.Crosscutting.NUnit.Extensions
{
    public abstract class AspActionFilterGivenWhenThen<TFilter> : GivenWhenThen<TFilter> where TFilter : IActionFilter
    {
        protected ActionExecutedContext MockActionExecutedContext;
        protected HttpRequest MockHttpRequest;
        protected HttpContext MockHttpContext;
        protected HeaderDictionary Headers;
        
        protected virtual Dictionary<string, StringValues> SetupHeaders( )
        {
            return new Dictionary<string, StringValues>( );
        }

        protected TType GetResultObject<TResult, TType>( ) where TResult : ObjectResult where TType : class
        {
            var objectResult = MockActionExecutedContext.Result as TResult;
            return objectResult?.Value as TType;
        }
        
        protected override void Given( )
        {
            MockHttpContext = Substitute.For<HttpContext>( );
            MockHttpRequest = Substitute.For<HttpRequest>( );
        }

        protected override void When( )
        {
            Headers = new HeaderDictionary( SetupHeaders( ) );
            MockHttpRequest
                .Headers
                .Returns( Headers );
            MockHttpContext
                .Request
                .Returns( MockHttpRequest );
            MockActionExecutedContext = new ActionExecutedContext( new ActionContext( MockHttpContext,
                new RouteData( ), new ActionDescriptor( ) ), new List<IFilterMetadata>( ), new object( ) );
        }
    }
}
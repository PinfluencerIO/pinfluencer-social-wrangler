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
        private HttpContext _mockHttpContext;
        private HttpRequest _mockHttpRequest;
        protected ActionExecutingContext MockActionExecutingContext;

        protected virtual Dictionary<string, StringValues> SetupHeaders( )
        {
            return new Dictionary<string, StringValues>( );
        }

        protected virtual Dictionary<string, StringValues> SetupQueryParams( )
        {
            return new Dictionary<string, StringValues>( );
        }
        
        protected virtual Dictionary<string, object> SetupActionArguments( )
        {
            return new Dictionary<string, object>( );
        }

        protected TType GetResultObject<TResult, TType>( ) where TResult : ObjectResult where TType : class
        {
            var objectResult = MockActionExecutingContext.Result as TResult;
            return objectResult?.Value as TType;
        }

        protected override void Given( )
        {
            _mockHttpContext = Substitute.For<HttpContext>( );
            _mockHttpRequest = Substitute.For<HttpRequest>( );
        }

        protected override void When( )
        {
            _mockHttpRequest
                .Headers
                .Returns( new HeaderDictionary( SetupHeaders( ) ) );
            _mockHttpRequest
                .Query
                .Returns( new QueryCollection( SetupQueryParams( ) ) );
            _mockHttpContext
                .Request
                .Returns( _mockHttpRequest );
            MockActionExecutingContext = new ActionExecutingContext( new ActionContext( _mockHttpContext,
                    new RouteData( ), new ActionDescriptor( ) ), new List<IFilterMetadata>( ),
                SetupActionArguments( ), new object( ) );
        }
    }
}
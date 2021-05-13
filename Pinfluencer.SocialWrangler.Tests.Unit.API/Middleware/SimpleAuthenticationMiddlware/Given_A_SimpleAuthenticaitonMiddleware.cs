using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Pinfluencer.SocialWrangler.API.Middleware;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Middleware.SimpleAuthenticationMiddlware
{
    public class Given_A_SimpleAuthenticaitonMiddleware : GivenWhenThen<SimpleAuthenticationMiddleware>
    {
        protected string ApiKeyFromConfig;
        protected IHeaderDictionary HeaderDictionary;
        protected IConfiguration MockConfiguration;
        protected HttpContext MockHttpContext;
        protected HttpRequest MockHttpRequest;

        protected HttpResponse MockHttpResponse;
        protected RequestDelegate MockNextMiddlware;

        protected override void Given( )
        {
            MockNextMiddlware = Substitute.For<RequestDelegate>( );
            MockConfiguration = Substitute.For<IConfiguration>( );
            MockHttpContext = Substitute.For<HttpContext>( );
            MockHttpResponse = Substitute.For<HttpResponse>( );
            MockHttpRequest = Substitute.For<HttpRequest>( );

            Sut = new SimpleAuthenticationMiddleware( MockNextMiddlware );
        }

        protected override void When( )
        {
            MockHttpRequest
                .Headers
                .Returns( HeaderDictionary );
            MockConfiguration
                    [ Arg.Any<string>( ) ]
                .Returns( ApiKeyFromConfig );

            MockHttpContext
                .Request
                .Returns( MockHttpRequest );
            MockHttpContext
                .Response
                .Returns( MockHttpResponse );

            Sut.Invoke(
                MockHttpContext,
                MockConfiguration
            );
        }
    }
}
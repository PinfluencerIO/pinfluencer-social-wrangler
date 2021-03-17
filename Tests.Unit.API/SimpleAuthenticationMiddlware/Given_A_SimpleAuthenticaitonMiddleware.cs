using API.InstaFetcher.Middleware;
using Crosscutting.Testing.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace Tests.Unit.API.SimpleAuthenticationMiddlware
{
    public class Given_A_SimpleAuthenticaitonMiddleware : GivenWhenThen<SimpleAuthenticationMiddleware>
    {
        protected RequestDelegate MockNextMiddlware;
        protected IConfiguration MockConfiguration;
        protected HttpContext MockHttpContext;
        
        protected HttpResponse MockHttpResponse;
        protected HttpRequest MockHttpRequest;
        protected IQueryCollection QueryParams;
        protected string ApiKeyFromConfig;

        protected override void Given()
        {
            MockNextMiddlware = Substitute.For<RequestDelegate>();
            MockConfiguration = Substitute.For<IConfiguration>();
            MockHttpContext = Substitute.For<HttpContext>();
            MockHttpResponse = Substitute.For<HttpResponse>();
            MockHttpRequest = Substitute.For<HttpRequest>();

            Sut = new SimpleAuthenticationMiddleware(MockNextMiddlware);
        }

        protected override void When()
        {
            MockHttpRequest
                .Query
                .Returns(QueryParams);
            MockConfiguration
                .GetValue<string>(Arg.Any<string>())
                .Returns(ApiKeyFromConfig);

            MockHttpContext
                .Request
                .Returns(MockHttpRequest);
            MockHttpContext
                .Response
                .Returns(MockHttpResponse);
            
            Sut.Invoke(
                MockHttpContext,
                MockConfiguration
            );
        }
    }
}
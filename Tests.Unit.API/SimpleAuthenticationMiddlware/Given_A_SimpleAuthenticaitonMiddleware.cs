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

        protected override void Given()
        {
            MockNextMiddlware = Substitute.For<RequestDelegate>();
            MockConfiguration = Substitute.For<IConfiguration>();
            MockHttpContext = Substitute.For<HttpContext>();

            Sut = new SimpleAuthenticationMiddleware(MockNextMiddlware);
            Sut.Invoke(
                MockHttpContext,
                MockConfiguration
            );
        }
    }
}
using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.DAL.UserManagement;

namespace Pinf.InstaService.Tests.Unit.API.Auth0Middlware
{
    //TODO: add tests for failing to parse URIs
    public abstract class Given_A_Auth0Middlware : GivenWhenThen<global::Pinf.InstaService.API.InstaFetcher.Middleware.Auth0Middlware>
    {
        protected const string TestToken = "123456789";
        protected IConfigurationSection MockAuth0Configuration;
        protected Auth0Context MockAuth0Context;
        protected IAuthenticationConnection MockAuthenticationConnection;
        protected IConfiguration MockConfiguration;
        protected HttpContext MockHttpContext;
        protected HttpResponse MockHttpResponse;
        protected IManagementConnection MockManagementConnection;
        protected RequestDelegate MockNextMiddlware;

        protected override void Given()
        {
            MockNextMiddlware = Substitute.For<RequestDelegate>();
            MockAuth0Context = Substitute.For<Auth0Context>();
            MockConfiguration = Substitute.For<IConfiguration>();
            MockAuth0Configuration = Substitute.For<IConfigurationSection>();
            MockHttpContext = Substitute.For<HttpContext>();
            MockManagementConnection = Substitute.For<IManagementConnection>();
            MockAuthenticationConnection = Substitute.For<IAuthenticationConnection>();
            MockHttpResponse = Substitute.For<HttpResponse>();

            MockHttpContext
                .Response
                .Returns(MockHttpResponse);

            Sut = new global::Pinf.InstaService.API.InstaFetcher.Middleware.Auth0Middlware(MockNextMiddlware);
        }

        protected override void When()
        {
            Sut.Invoke(
                MockHttpContext,
                MockAuth0Context,
                MockConfiguration,
                MockManagementConnection,
                MockAuthenticationConnection
            );
        }

        protected void AddDefaultConfiguration()
        {
            MockAuth0Configuration
                    [Arg.Is("Id")]
                .Returns("12345");
            MockAuth0Configuration
                    [Arg.Is("Secret")]
                .Returns("54321");
            MockAuth0Configuration
                    [Arg.Is("Domain")]
                .Returns("www.management/api");
            MockAuth0Configuration
                    [Arg.Is("ManagementDomain")]
                .Returns("www.management/api");
        }

        protected void AddConfiguration(string key, string value)
        {
            MockAuth0Configuration
                    [Arg.Is(key)]
                .Returns(value);
        }

        protected void SetConfiguration()
        {
            MockConfiguration
                .GetSection(Arg.Is("Auth0"))
                .Returns(MockAuth0Configuration);
        }
    }
}
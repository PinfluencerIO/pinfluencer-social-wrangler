using Auth0.ManagementApi;
using Crosscutting.Testing.Extensions;
using DAL.UserManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace Tests.Unit.API.Auth0Middlware
{
    public class Given_A_Auth0Middlware : GivenWhenThen<global::API.InstaFetcher.Middleware.Auth0Middlware>
    {
        protected RequestDelegate MockNextMiddlware;
        protected IConfiguration MockConfiguration;
        protected IConfigurationSection MockAuth0Configuration;
        protected HttpContext MockHttpContext;
        protected HttpResponse MockHttpResponse;
        protected Auth0Context MockAuth0Context;
        protected IManagementConnection MockManagementConnection;

        protected override void Given()
        {
            MockNextMiddlware = Substitute.For<RequestDelegate>();
            MockAuth0Context = Substitute.For<Auth0Context>();
            MockConfiguration = Substitute.For<IConfiguration>();
            MockAuth0Configuration = Substitute.For<IConfigurationSection>();
            MockHttpContext = Substitute.For<HttpContext>();
            MockManagementConnection = Substitute.For<IManagementConnection>();
            MockHttpResponse = Substitute.For<HttpResponse>();

            MockHttpContext
                .Response
                .Returns(MockHttpResponse);

            MockAuth0Configuration
                .GetValue<string>(Arg.Is("Id"))
                .Returns("12345");
            MockAuth0Configuration
                .GetValue<string>(Arg.Is("Secret"))
                .Returns("54321");
            MockAuth0Configuration
                .GetValue<string>(Arg.Is("Domain"))
                .Returns("domain/domain");
            MockAuth0Configuration
                .GetValue<string>(Arg.Is("ManagementDomain"))
                .Returns("management/api/domain");
            
            MockConfiguration
                .GetSection(Arg.Is("Auth0"))
                .Returns(MockAuth0Configuration);

            Sut = new global::API.InstaFetcher.Middleware.Auth0Middlware(MockNextMiddlware);

            Sut.Invoke(
                MockHttpContext,
                MockAuth0Context,
                MockConfiguration,
                MockManagementConnection
            );
        }

        protected override void When()
        {
            Sut.Invoke(
                MockHttpContext,
                MockAuth0Context,
                MockConfiguration,
                MockManagementConnection
            );
        }

        protected void AddDefaultConfiguration()
        {
            MockAuth0Configuration
                .GetValue<string>(Arg.Is("Id"))
                .Returns("12345");
            MockAuth0Configuration
                .GetValue<string>(Arg.Is("Secret"))
                .Returns("54321");
            MockAuth0Configuration
                .GetValue<string>(Arg.Is("Domain"))
                .Returns("domain/domain");
            MockAuth0Configuration
                .GetValue<string>(Arg.Is("ManagementDomain"))
                .Returns("management/api/domain");
        }
        
        protected void AddConfiguration(string key, string value)
        {
            MockAuth0Configuration
                .GetValue<string>(Arg.Is(key))
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
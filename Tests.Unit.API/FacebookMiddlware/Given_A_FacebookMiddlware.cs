using System.Collections.Generic;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Factories;
using Bootstrapping.Services.Repositories;
using Crosscutting.Testing.Extensions;
using DAL.Instagram;
using Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;

namespace Tests.Unit.API.FacebookMiddlware
{
    public abstract class
        Given_A_FacebookMiddlware : GivenWhenThen<global::API.InstaFetcher.Middleware.FacebookMiddlware>
    {
        protected const string TestAuth0Id = "12345";
        protected FacebookContext FacebookContext;
        protected FacebookClient MockFacebookClient;
        protected IFacebookClientFactory MockFacebookClientFactory;
        protected HttpContext MockHttpContext;
        protected HttpRequest MockHttpRequest;
        protected HttpResponse MockHttpResponse;
        protected RequestDelegate MockNextMiddlware;
        protected IUserRepository MockUserRepository;

        protected string TestToken = "654321";
        protected OperationResultEnum TokenFetchResult;

        protected override void Given()
        {
            MockNextMiddlware = Substitute.For<RequestDelegate>();
            MockHttpContext = Substitute.For<HttpContext>();
            MockUserRepository = Substitute.For<IUserRepository>();
            FacebookContext = new FacebookContext();
            MockFacebookClientFactory = Substitute.For<IFacebookClientFactory>();
            MockFacebookClient = Substitute.For<FacebookClient>();

            Sut = new global::API.InstaFetcher.Middleware.FacebookMiddlware(MockNextMiddlware);
        }

        protected override void When()
        {
            MockHttpResponse = Substitute.For<HttpResponse>();

            MockFacebookClientFactory
                .Get(Arg.Any<string>())
                .Returns(MockFacebookClient);

            MockHttpContext
                .Response
                .Returns(MockHttpResponse);
            MockHttpContext
                .Request
                .Returns(MockHttpRequest);
            MockUserRepository
                .GetInstagramToken(Arg.Any<string>())
                .Returns(new OperationResult<string>(TestToken, TokenFetchResult));

            Sut.Invoke(
                MockHttpContext,
                MockUserRepository,
                FacebookContext,
                MockFacebookClientFactory
            );
        }

        protected void SetAuth0Id()
        {
            MockHttpRequest = Substitute.For<HttpRequest>();
            var queryParams = new Dictionary<string, StringValues>();
            queryParams.Add("auth0_id", new StringValues(TestAuth0Id));

            SetQueryParams(queryParams);
        }

        protected void SetEmptyAuth0Id()
        {
            MockHttpRequest = Substitute.For<HttpRequest>();
            var queryParams = new Dictionary<string, StringValues>();

            SetQueryParams(queryParams);
        }

        private void SetQueryParams(Dictionary<string, StringValues> queryParams)
        {
            MockHttpRequest
                .Query
                .Returns(new QueryCollection(queryParams));
        }
    }
}
using System;
using API.InstaFetcher.Middleware;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Factories;
using Bootstrapping.Services.Repositories;
using Crosscutting.Testing.Extensions;
using DAL.Instagram;
using DAL.Instagram.Dtos;
using Facebook;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Unit.API.Middlware
{
    public abstract class Given_A_FacebookMiddlware : GivenWhenThen<FacebookMiddlware>
    {
        protected RequestDelegate MockNextMiddlware;
        protected HttpContext MockHttpContext;
        protected IUserRepository MockUserRepository;
        protected FacebookContext FacebookContext;
        protected IFacebookClientFactory MockFacebookClientFactory;
        protected FacebookClient MockFacebookClient;

        protected const string TestToken = "";
        protected OperationResultEnum TokenFetchResult;
        protected HttpResponse MockHttpResponse;

        protected override void Given()
        {
            MockNextMiddlware = Substitute.For<RequestDelegate>();
            MockHttpContext = Substitute.For<HttpContext>();
            MockUserRepository = Substitute.For<IUserRepository>();
            FacebookContext = new FacebookContext();
            MockFacebookClientFactory = Substitute.For<IFacebookClientFactory>();
            MockFacebookClient = Substitute.For<FacebookClient>();

            Sut = new FacebookMiddlware(MockNextMiddlware);
        }

        protected override void When()
        {
            MockFacebookClientFactory
                .Get(Arg.Any<string>())
                .Returns(MockFacebookClient);

            MockHttpResponse = Substitute.For<HttpResponse>();
            MockHttpContext
                .Response
                .Returns(MockHttpResponse);
            MockUserRepository
                .GetInstagramToken(Arg.Any<string>())
                .Returns(new OperationResult<string>(TestToken,TokenFetchResult));
            
            Sut.Invoke(
                MockHttpContext,
                MockUserRepository,
                FacebookContext,
                MockFacebookClientFactory
            );
        }

        [Test]
        public void Then_Token_Was_Inspected()
        {
            MockFacebookClient
                .Received()
                .Get("debug_token", Arg.Any<object>());
        }
        
        [Test]
        public void Then_Correct_Token_Was_Inspected()
        {
            MockFacebookClient
                .Received()
                .Get(Arg.Any<string>(), Arg.Is<RequestDebugTokenParams>(x => x.input_token.Equals(TestToken)));
        }
        
        [Test]
        public void Then_Graph_Api_Was_Called_Once()
        {
            MockFacebookClient
                .Received(1)
                .Get(Arg.Any<string>(), Arg.Any<object>());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Facebook;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;
using HttpMethod = System.Net.Http.HttpMethod;

namespace Tests.Unit.API.Auth0Middlware
{
    public class When_Successful : Given_A_Auth0Middlware
    {
        protected override void When()
        {
            AddDefaultConfiguration();
            SetConfiguration();

            MockAuthenticationConnection
                .SendAsync<AccessTokenResponse>(
                    Arg.Any<HttpMethod>(),
                    Arg.Any<Uri>(),
                    Arg.Any<object>(),
                    Arg.Any<IDictionary<string, string>>()
                )
                .Returns(Task.FromResult(new AccessTokenResponse{AccessToken = TestToken}));
            
            base.When();
        }

        [Test]
        public void Then_Next_Middlware_Is_Executed()
        {
            MockNextMiddlware
                .Received(1)
                .Invoke(Arg.Any<HttpContext>());
        }
    }
}
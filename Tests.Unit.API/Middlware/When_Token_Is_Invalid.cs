using System;
using System.Threading.Tasks;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Facebook;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Tests.Unit.API.Middlware
{
    public class When_Token_Is_Invalid : Given_A_FacebookMiddlware
    {
        protected override void When()
        {
            MockFacebookClient
                .Get(Arg.Any<string>(),Arg.Any<object>())
                .Throws<FacebookOAuthException>();

            base.When();
        }

        [Test]
        public void Then_Middlware_Short_Circuits()
        {
            MockNextMiddlware
                .DidNotReceive()
                .Invoke(Arg.Any<HttpContext>());
        }

        [Test]
        public void Then_Response_Status_Code_Was_Not_Authorized()
        {
            MockHttpResponse
                .Received()
                .StatusCode = Arg.Is(401);
        }
        
        [Test]
        public void Then_Response_Status_Code_Was_Set_Once()
        {
            MockHttpResponse
                .Received(1)
                .StatusCode = Arg.Any<int>();
        }
    }
}
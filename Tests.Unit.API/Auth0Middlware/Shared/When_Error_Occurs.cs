using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Unit.API.Auth0Middlware.Shared
{
    public abstract class When_Error_Occurs : Given_A_Auth0Middlware
    {
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
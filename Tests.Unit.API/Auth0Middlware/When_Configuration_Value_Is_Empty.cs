using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Unit.API.Auth0Middlware
{
    [TestFixture("Id")]
    [TestFixture("Secret")]
    [TestFixture("Domain")]
    [TestFixture("ManagementDomain")]
    public class When_Configuration_Value_Is_Empty : Given_A_Auth0Middlware
    {
        private readonly string _key;

        public When_Configuration_Value_Is_Empty(string key)
        {
            _key = key;
        }
        
        protected override void When()
        {
            AddDefaultConfiguration();
            AddConfiguration(_key, default);
            SetConfiguration();
            
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
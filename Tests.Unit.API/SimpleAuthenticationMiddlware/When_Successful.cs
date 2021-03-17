using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Unit.API.SimpleAuthenticationMiddlware
{
    public class When_Successful : Given_A_SimpleAuthenticaitonMiddleware
    {
        protected override void When()
        {
            var queryParams = new Dictionary<string, StringValues>();
            queryParams.Add("InstaServiceKey","TestKey");
            HeaderDictionary = new HeaderDictionary(queryParams);
            ApiKeyFromConfig = "TestKey";

            base.When();
        }

        [Test]
        public void Then_Next_Middlware_Is_Run()
        {
            MockNextMiddlware
                .Received(1)
                .Invoke(Arg.Any<HttpContext>());
        }
    }
}
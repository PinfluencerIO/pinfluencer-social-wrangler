using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Tests.Unit.API.SimpleAuthenticationMiddlware.Shared;

namespace Tests.Unit.API.SimpleAuthenticationMiddlware
{
    public class When_Keys_Dont_Match : When_Error_Occurs
    {
        protected override void When()
        {
            var headerParams = new Dictionary<string, StringValues>();
            headerParams.Add("InstaServiceKey","TestKey");
            HeaderDictionary = new HeaderDictionary(headerParams);
            ApiKeyFromConfig = "TestKey1";

            base.When();
        }
    }
}
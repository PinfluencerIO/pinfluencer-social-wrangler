using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Tests.Unit.API.SimpleAuthenticationMiddlware.Shared;

namespace Tests.Unit.API.SimpleAuthenticationMiddlware
{
    public class When_Key_Is_Not_Present_In_Configuration : When_Error_Occurs
    {
        protected override void When()
        {
            var headerParams = new Dictionary<string, StringValues>();
            headerParams.Add("InstaServiceKey", "TestKey");
            HeaderDictionary = new HeaderDictionary(headerParams);
            ApiKeyFromConfig = null;

            base.When();
        }
    }
}
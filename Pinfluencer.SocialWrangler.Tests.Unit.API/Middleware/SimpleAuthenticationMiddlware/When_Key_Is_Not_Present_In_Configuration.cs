using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Middleware.SimpleAuthenticationMiddlware.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Middleware.SimpleAuthenticationMiddlware
{
    public class When_Key_Is_Not_Present_In_Configuration : When_Error_Occurs
    {
        protected override void When( )
        {
            var headerParams = new Dictionary<string, StringValues>( );
            headerParams.Add( "Simple-Auth-Key", "TestKey" );
            HeaderDictionary = new HeaderDictionary( headerParams );
            ApiKeyFromConfig = null;

            base.When( );
        }
    }
}
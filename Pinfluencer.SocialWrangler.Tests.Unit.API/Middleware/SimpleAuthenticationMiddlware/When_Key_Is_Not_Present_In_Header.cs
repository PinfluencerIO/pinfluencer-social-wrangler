using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Middleware.SimpleAuthenticationMiddlware.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Middleware.SimpleAuthenticationMiddlware
{
    [ TestFixture( "key" ) ]
    [ TestFixture( null ) ]
    public class When_Key_Is_Not_Present_In_Header : When_Error_Occurs
    {
        public When_Key_Is_Not_Present_In_Header( string configKey ) { ApiKeyFromConfig = configKey; }

        protected override void When( )
        {
            var headerParams = new Dictionary<string, StringValues>( );
            HeaderDictionary = new HeaderDictionary( headerParams );

            base.When( );
        }
    }
}
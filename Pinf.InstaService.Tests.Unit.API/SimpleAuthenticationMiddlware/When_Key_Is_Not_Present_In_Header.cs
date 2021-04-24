﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using Pinf.InstaService.Tests.Unit.API.SimpleAuthenticationMiddlware.Shared;

namespace Pinf.InstaService.Tests.Unit.API.SimpleAuthenticationMiddlware
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
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests
{
    [ TestFixture( ApiKey, "otherkey" ) ]
    [ TestFixture( "otherkey", ApiKey ) ]
    public class When_Keys_Dont_Match : When_Error_Occurs
    {
        private readonly string _configKey;
        private readonly string _headerKey;

        public When_Keys_Dont_Match( string configKey, string headerKey )
        {
            _configKey = configKey;
            _headerKey = headerKey;
        }

        protected override Dictionary<string, StringValues> SetupHeaders( )
        {
            return new Dictionary<string, StringValues> { { ApiKeyName, _headerKey } };
        }

        protected override void When( )
        {
            base.When( );
            MockConfiguration[ ApiKeyName ].Returns( _configKey );
            SUT.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Error_Message_Is_Valid( ) { Assert.AreEqual( "api keys do not match", ErrorMessage ); }
    }
}
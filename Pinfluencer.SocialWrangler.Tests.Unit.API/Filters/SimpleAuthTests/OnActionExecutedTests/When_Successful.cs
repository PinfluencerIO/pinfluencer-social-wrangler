using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests
{
    public class When_Successful : Given_A_SimpleAuthFilter
    {
        protected override Dictionary<string, StringValues> SetupHeaders( )
        {
            return new Dictionary<string, StringValues>
                { { ApiKeyName, ApiKey } };
        }

        protected override void When( )
        {
            base.When( );
            MockConfiguration[ ApiKeyName ].Returns( ApiKey );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Next_Action_Is_Run( ) { Assert.Null( MockActionExecutingContext.Result ); }
    }
}
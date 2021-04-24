using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests
{
    public class When_Successful : Given_A_Simple_Auth_Filter
    {
        protected override Dictionary<string, StringValues> SetupHeaders( ) => new Dictionary<string, StringValues>
            { { ApiKeyName, ApiKey } };

        protected override void When( )
        {
            base.When( );
            MockConfiguration [ ApiKeyName ].Returns( ApiKey );
            Sut.OnActionExecuted( MockActionExecutedContext );
        }

        [ Test ]
        public void Then_Next_Action_Is_Run( )
        {
            Assert.Null( MockActionExecutedContext.Result );
        }
    }
}
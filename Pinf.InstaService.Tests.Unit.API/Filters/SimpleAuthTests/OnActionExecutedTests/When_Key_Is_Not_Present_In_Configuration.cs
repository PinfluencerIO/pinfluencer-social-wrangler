using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests
{
    public class When_Key_Is_Not_Present_In_Configuration : When_Error_Occurs
    {
        protected override Dictionary<string, StringValues> SetupHeaders( )
        {
            return new Dictionary<string, StringValues> { { ApiKeyName, ApiKey } };
        }

        protected override void When( )
        {
            base.When( );
            MockConfiguration[ ApiKeyName ].Returns( default( string ) );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Error_Message_Is_Valid( )
        {
            Assert.AreEqual( "api key is not present in server", ErrorMessage );
        }
    }
}
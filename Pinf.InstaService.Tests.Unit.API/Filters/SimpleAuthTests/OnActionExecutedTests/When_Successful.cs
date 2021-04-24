using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests
{
    public class When_Successful : Given_A_Simple_Auth_Filter
    {
        protected override Dictionary<string, StringValues> SetupHeaders( )
        {
            var dict = new Dictionary<string, StringValues>( );
            dict.Add( "test", "abc" );
            return dict;
        }

        protected override void When( )
        {
            base.When( );
            Sut.OnActionExecuted( MockActionExecutedContext );
        }

        [ Test ]
        public void Then_Next_Action_Is_Run( )
        {
            Assert.Null( MockActionExecutedContext.Result );
        }
    }
}
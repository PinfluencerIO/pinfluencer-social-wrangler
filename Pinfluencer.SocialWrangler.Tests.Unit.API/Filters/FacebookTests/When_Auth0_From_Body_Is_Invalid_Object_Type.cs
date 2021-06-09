using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests
{
    public class When_Auth0_From_Body_Is_Invalid_Object_Type : When_Error_Occurs
    {
        protected override Dictionary<string, StringValues> SetupQueryParams( )
        {
            return new Dictionary<string, StringValues>( );
        }

        protected override Dictionary<string, object> SetupActionArguments( )
        {
            return new Dictionary<string, object> { { UserActionArgumentKey, new { Auth0User = Auth0IdParamKey } } };
        }

        protected override void When( )
        {
            base.When( );
            SUT.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Error_Message_Is_Valid( )
        {
            Assert.AreEqual( "'auth-user' parameter was not present in the request", ErrorMessage );
        }

        [ Test ]
        public void Then_Social_Was_Not_Authenticated( )
        {
            MockSocialAuthManager
                .DidNotReceive( )
                .Initialize( Arg.Any<string>(  ) );
        }
    }
}
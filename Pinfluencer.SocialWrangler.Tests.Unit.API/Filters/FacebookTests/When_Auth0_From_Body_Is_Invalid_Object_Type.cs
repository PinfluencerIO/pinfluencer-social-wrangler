using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
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
            SetUpUserRepository( TestToken, OperationResultEnum.Success );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Error_Message_Is_Valid( )
        {
            Assert.AreEqual( "'auth-id' parameter was not present in the request", ErrorMessage );
        }

        [ Test ]
        public void Then_Instagram_Api_Is_Not_Called( )
        {
            MockUserRepository
                .DidNotReceive( )
                .GetInstagramToken( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Graph_Api_Was_Not_Called( )
        {
            MockFacebookClient
                .DidNotReceive( )
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) );
        }
    }
}
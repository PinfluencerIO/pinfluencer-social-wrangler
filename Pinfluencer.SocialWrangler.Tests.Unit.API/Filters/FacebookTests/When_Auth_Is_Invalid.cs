using System.Net;
using Facebook;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests
{
    public class When_Auth_Is_Invalid : When_Auth0_Communication_Was_Successful
    {
        protected override void When( )
        {
            base.When( );
            MockSocialAuthManager
                .Initialize( Arg.Any<string>( ) )
                .Returns( new Result { Status = OperationResultEnum.Failed, Msg = "some msg" } );
            SUT.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Middlware_Short_Circuits( ) { Assert.NotNull( MockActionExecutingContext.Result ); }

        [ Test ]
        public void Then_Result_Status_Is_Unauthorized( )
        {
            Assert.AreEqual( 401, ( ( ContentResult ) MockActionExecutingContext.Result ).StatusCode );
        }
    }
}
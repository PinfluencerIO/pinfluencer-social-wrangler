using System.Net;
using Facebook;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests
{
    public class When_Token_Is_Invalid : When_Auth0_Communication_Was_Successful
    {
        private const string FacebookErrorMsg = "facebook error message";

        protected override void When( )
        {
            base.When( );
            SetUpUserRepository( TestToken, OperationResultEnum.Success );
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( new FacebookOAuthException( FacebookErrorMsg ) );
            SUT.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Middlware_Short_Circuits( ) { Assert.NotNull( MockActionExecutingContext.Result ); }

        [ Test ]
        public void Then_Result_Status_Is_Unauthorized( )
        {
            Assert.AreEqual( HttpStatusCode.Unauthorized.GetHashCode( ),
                ( MockActionExecutingContext.Result as ContentResult ).StatusCode );
        }

        [ Test ]
        public void Then_Error_Message_Is_Valid( ) { Assert.AreEqual( FacebookErrorMsg, ErrorMessage ); }
    }
}
using Aidan.Common.Core.Enum;
using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookAuthManagerTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookAuthManagerTests
{
    public class When_Token_Is_Invalid : When_Auth0_Communication_Was_Successful
    {
        private const string FacebookErrorMsg = "facebook error message";

        protected override void When( )
        {
            base.When( );
            SetUpUserRepository( TestToken, OperationResultEnum.Success );
            MockFacebookDecorator
                .Get<object>( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( new FacebookOAuthException( FacebookErrorMsg ) );
            Result = SUT.Initialize( TestAuth0Id );
        }

        [ Test ]
        public void Then_Error_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }

        [ Test ]
        public void Then_Error_Message_Is_Valid( ) { Assert.AreEqual( FacebookErrorMsg, Result.Msg ); }
    }
}
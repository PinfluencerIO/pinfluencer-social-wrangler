using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookAuthManagerTests
{
    public class When_Auth0_Error_Occurs : Given_A_FacebookAuthManager
    {
        protected override void When( )
        {
            base.When( );
            SetUpUserRepository( "", OperationResultEnum.Failed );
            Result = SUT.Initialize( TestAuth0Id );
        }

        [ Test ]
        public void Then_Error_Message_Is_Valid( )
        {
            Assert.AreEqual( "auth0 id did not match an existing user", Result.Msg );
        }

        [ Test ]
        public void Then_Error_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }

        [ Test ]
        public void Then_User_Repository_Was_Fetched_From_Once( )
        {
            FacebookTokenRepository
                .Received( 1 )
                .Get( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Valid_Auth0_Id_Was_Used( )
        {
            FacebookTokenRepository
                .Received( )
                .Get( Arg.Is( TestAuth0Id ) );
        }

        [ Test ]
        public void Then_Graph_Api_Was_Not_Called( )
        {
            MockFacebookDecorator
                .DidNotReceive( )
                .Get<object>( Arg.Any<string>( ), Arg.Any<object>( ) );
        }
    }
}
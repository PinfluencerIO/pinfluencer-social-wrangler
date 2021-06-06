using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Auth0AuthManagerTests
{
    public class When_Successful : Given_An_Auth0AuthManager
    {
        protected override void When( )
        {
            base.When( );
            
            MockAuth0AuthenticationClient
                .GetToken( Arg.Any< ( string, string, string )>( ) )
                .Returns( TestToken );
            Result = SUT.Initialize( );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, Result.Status ); }

        [ Test ]
        public void Then_Token_Is_Fetched_Once( ) { TokenWasFetchedOnce( ); }

        [ Test ]
        public void Then_Token_Is_Fetched_With_Valid_Body( ) { TokenWasFetchedWithValidBody( ); }

        [ Test ]
        public void Then_Management_Api_Client_Was_Set( )
        { 
            MockAuth0ManagementClientDecorator
                .Received( )
                .Secret = Arg.Any<string>( ); 
        }
    }
}
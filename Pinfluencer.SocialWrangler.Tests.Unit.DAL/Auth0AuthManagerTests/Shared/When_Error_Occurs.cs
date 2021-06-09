using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Auth0AuthManagerTests.Shared
{
    public abstract class When_Error_Occurs : Given_An_Auth0AuthManager
    {
        [ Test ]
        public void Then_Error_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }

        [ Test ]
        public void Then_Management_Api_Client_Was_Not_Set( )
        { 
            MockAuth0ManagementClientDecorator
                .DidNotReceive( )
                .Secret = Arg.Any<string>( ); 
        }
    }
}
using Aidan.Common.Core.Enum;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookAuthManagerTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookAuthManagerTests
{
    public class When_Successful : When_Auth0_Communication_Was_Successful
    {
        protected override void When( )
        {
            base.When( );
            SetUpUserRepository( TestToken, OperationResultEnum.Success );
            Result = SUT.Initialize( TestAuth0Id );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, Result.Status ); }
    }
}
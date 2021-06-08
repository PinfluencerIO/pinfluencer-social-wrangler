using System.Linq;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialUserFacadeTests.GetUsersTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialUserFacadeTests.GetUsersTests.FailTests
{
    public class When_Get_Insta_Users_Fails : When_Get_All_Is_Called
    {
        protected override void When( )
        {
            InstaUserCollection = Enumerable.Empty<SocialInsightsUser>( );
            InstaUsersOperationResult = OperationResultEnum.Failed;

            base.When( );

            Result = SUT.GetUsers( );
        }

        [ Test ]
        public void Then_Operation_Result_Fails( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }
    }
}
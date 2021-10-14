using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate
{
    public class When_User_Cannot_Be_Fetched : When_Called
    {
        private ObjectResult<double> _result;

        protected override void When( )
        {
            MockSocialInsightsUserFacade
                .GetFirstUser( )
                .Returns( new ObjectResult<SocialInsightsUser>
                {
                    Status = OperationResultEnum.Failed,
                    Value = null
                } );
            _result = SUT.GetEngagementRate( );
        }

        [ Test ]
        public void Then_Failed_Status_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Failed, _result.Status );
        }
    }
}
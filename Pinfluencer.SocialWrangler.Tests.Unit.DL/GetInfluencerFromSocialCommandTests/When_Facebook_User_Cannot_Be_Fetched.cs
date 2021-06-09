using System.Collections.Generic;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests
{
    public class When_Facebook_User_Cannot_Be_Fetched : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockInsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>( new [ ] { DefaultSocialInsightsUser },
                    OperationResultEnum.Success ) );
            MockSocialInfoUserRepository
                .Get( )
                .Returns( new ObjectResult<SocialInfoUser>( new SocialInfoUser( ),
                    OperationResultEnum.Failed ) );
            Result = SUT.Run( );
        }
    }
}
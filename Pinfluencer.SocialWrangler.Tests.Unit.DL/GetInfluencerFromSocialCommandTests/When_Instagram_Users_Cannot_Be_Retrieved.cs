using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests
{
    public class When_Instagram_Users_Cannot_Be_Retrieved : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockInsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>( Enumerable.Empty<SocialInsightsUser>( ),
                    OperationResultEnum.Failed ) );
            Result = SUT.Run( );
        }
    }
}
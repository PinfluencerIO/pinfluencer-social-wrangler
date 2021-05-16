using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests
{
    public class When_Instagram_Users_Cannot_Be_Retrieved : When_Instagram_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            InsightsSocialUserRepository
                .GetAll( )
                .Returns( new OperationResult<IEnumerable<SocialInsightsUser>>( Enumerable.Empty<SocialInsightsUser>(  ), OperationResultEnum.Failed ) );
            Result = Sut.OnboardInfluencer( "123" );
        }
    }
}
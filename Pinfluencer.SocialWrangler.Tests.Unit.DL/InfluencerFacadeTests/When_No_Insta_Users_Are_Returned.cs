using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests
{
    public class When_No_Insta_Users_Are_Returned : When_Instagram_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            InsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>( Enumerable.Empty<SocialInsightsUser>( ),
                    OperationResultEnum.Success ) );
            Result = SUT.OnboardInfluencer( "123" );
        }
    }
}
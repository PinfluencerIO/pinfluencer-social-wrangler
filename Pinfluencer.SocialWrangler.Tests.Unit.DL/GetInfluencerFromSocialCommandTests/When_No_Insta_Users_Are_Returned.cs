﻿using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests
{
    public class When_No_Insta_Users_Are_Returned : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockInsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>( Enumerable.Empty<SocialInsightsUser>( ),
                    OperationResultEnum.Success ) );
            Result = SUT.Run( );
        }
    }
}
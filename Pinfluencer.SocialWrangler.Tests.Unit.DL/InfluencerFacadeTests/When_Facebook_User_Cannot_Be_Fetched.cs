using System.Collections.Generic;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests
{
    public class When_Facebook_User_Cannot_Be_Fetched : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<User>( DefaultUser, OperationResultEnum.Success ) );
            InsightsSocialUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>( new [ ] { DefaultSocialInsightsUser },
                    OperationResultEnum.Success ) );
            SocialInfoUserRepository
                .Get( )
                .Returns( new ObjectResult<SocialInfoUser>( new SocialInfoUser( ),
                    OperationResultEnum.Failed ) );
            Result = SUT.OnboardInfluencer( "123" );
        }
    }
}
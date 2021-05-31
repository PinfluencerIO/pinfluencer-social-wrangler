using System.Collections.Generic;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests
{
    public class When_Facebook_User_Cannot_Be_Fetched : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new OperationResult<User>( DefaultUser, OperationResultEnum.Success ) );
            InsightsSocialUserRepository
                .GetAll( )
                .Returns( new OperationResult<IEnumerable<SocialInsightsUser>>( new [ ] { DefaultSocialInsightsUser }, OperationResultEnum.Success ) );
            SocialInfoUserRepository
                .Get( )
                .Returns( new OperationResult<ISocialInfoUser>( GetSocialInfoUser( new FakeSocialInfoUserProps( ) ),
                    OperationResultEnum.Failed ) );
            Result = SUT.OnboardInfluencer( "123" );
        }
    }
}
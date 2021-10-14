using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests
{
    public class When_Influencer_Cannot_Be_Created : When_Error_Occurs
    {
        protected override void When( )
        {
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<User>( DefaultUser, OperationResultEnum.Success ) );
            MockGetInfluencerFromSocialCommand
                .Run( )
                .Returns( new ObjectResult<Influencer>( DefaultInfluencerFromSocial,
                    OperationResultEnum.Success ) );
            MockInfluencerRepository
                .Create( Arg.Any<Influencer>( ) )
                .Returns( OperationResultEnum.Failed );
            Result = SUT.Onboard( "123" );
        }
    }
}
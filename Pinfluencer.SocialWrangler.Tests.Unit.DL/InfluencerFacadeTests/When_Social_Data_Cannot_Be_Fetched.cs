using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InfluencerFacadeTests
{
    public class When_Social_Data_Cannot_Be_Fetched : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<User>( DefaultUser, OperationResultEnum.Success ) );
            MockGetInfluencerFromSocialCommand
                .Run( )
                .Returns( new ObjectResult<Influencer>
                {
                    Status = OperationResultEnum.Failed,
                    Value = null
                } );
            Result = SUT.Onboard( "123" );
        }
    }
}
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InfluencerFacadeTests
{
    public class When_Bubble_User_Is_Not_Retrieved : When_Error_Occurs
    {
        protected override void When( )
        {
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new OperationResult<User>( new User( ), OperationResultEnum.Failed ) );
            Result = SUT.OnboardInfluencer( "123" );
        }

        [ Test ]
        public void Then_Create_Influencer_Was_Not_Called( )
        {
            MockInfluencerRepository
                .DidNotReceive( )
                .Create( Arg.Any<Influencer>( ) );
        }
    }
}
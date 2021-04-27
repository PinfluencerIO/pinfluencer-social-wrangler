using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get.Shared
{
    public abstract class When_Called : Given_A_UserRepository
    {
        [ Test ]
        public void Then_Profile_Will_Be_Verified_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Correct_Profile_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( 1 )
                .Get<TypeResponse<Profile>>( Arg.Is<string>( uri => uri == "profile/1234" ) );
        }
    }
}
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get.Shared
{
    public abstract class When_Facebook_Error_Does_Not_Occur : When_Called
    {
        [ Test ]
        public void Then_Bubble_Profile_Will_Be_Fetched_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Correct_Bubble_Profile_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( 1 )
                .Get<TypeResponse<Profile>>( Arg.Is<string>( uri => uri == "profile/1234" ) );
        }
    }
}
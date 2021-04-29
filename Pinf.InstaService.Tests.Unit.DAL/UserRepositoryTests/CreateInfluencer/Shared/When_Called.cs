using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Influencer = Pinf.InstaService.Core.Models.User.Influencer;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.CreateInfluencer.Shared
{
    public abstract class When_Called : Given_A_UserRepository
    {
        protected static readonly Influencer DefaultInfluencer = new Influencer
        {
            InstagramHandle = "example",
            Age = 24,
            Bio = "this an example bio",
            Gender = GenderEnum.Male,
            Location = "Uxbridge, West London",
            User = new User
            {
                Id = "123456"
            }
        };
    
        [ Test ]
        public void Then_Influencer_Will_Be_Created_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Post( Arg.Any<string>( ), Arg.Any<Influencer>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Post( Arg.Is<string>( uri => uri == "influencer" ), Arg.Any<Influencer>( ) );
        }
    }
}
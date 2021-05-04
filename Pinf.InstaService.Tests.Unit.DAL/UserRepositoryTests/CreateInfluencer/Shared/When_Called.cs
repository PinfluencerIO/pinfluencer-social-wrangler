using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.User;
using Influencer = Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble.Influencer;
using InfluencerModel = Pinf.InstaService.Core.Models.User.Influencer;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.CreateInfluencer.Shared
{
    public abstract class When_Called : Given_A_UserRepository
    {
        protected InfluencerModel GetDefaultInfluencer()
        {
            User.Id = "12345678";
            return new InfluencerModel
            {
                InstagramHandle = "example",
                Age = 24,
                Bio = "this an example bio",
                Gender = GenderEnum.Male,
                Location = "Uxbridge, West London",
                User = User
            };
        }

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
        
        [ Test ]
        public void Then_Valid_Influencer_Is_Created( )
        {
            MockBubbleClient
                .Received( )
                .Post( Arg.Any<string>( ),
                    Arg.Is<Influencer>(
                        x => x.Bio == GetDefaultInfluencer().Bio &&
                             x.Instagram == GetDefaultInfluencer().InstagramHandle &&
                             x.Profile == GetDefaultInfluencer().User.Id &&
                             x.Age == GetDefaultInfluencer().Age &&
                             x.Location == GetDefaultInfluencer().Location ) );
        }
    }
}
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;
using Influencer = Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble.Influencer;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InfluencerRepositoryTests
{
    public class Given_A_InfluencerRepository : DataGivenWhenThen<InfluencerRepository>
    {
        protected InfluencerModel DefaultInfluencer
        {
            get
            {
                
                SocialInfoUser.Id = "12345678";
                return new InfluencerModel
                {
                    SocialUsername = "example",
                    Age = 24,
                    Bio = "this an example bio",
                    Gender = GenderEnum.Male,
                    Location = "Uxbridge, West London",
                    User = new User{ Id = "12345678" }
                };
            }
        }
        
        protected override void Given( )
        {
            base.Given( );
            SUT = new InfluencerRepository( MockBubbleDataHandler );
        }
    }
}
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InfluencerRepositoryTests
{
    public class Given_A_InfluencerRepository : DataGivenWhenThen<BubbleInfluencerRepository>
    {
        protected InfluencerModel DefaultInfluencer =>
            new InfluencerModel
            {
                SocialUsername = "example",
                Age = 24,
                Bio = "this an example bio",
                Gender = GenderEnum.Male,
                Location = new LocationProperty
                {
                    City = "Uxbridge",
                    Country = "United Kingdom"
                },
                User = new User { Id = "12345678" }
            };

        protected override void Given( )
        {
            base.Given( );
            SUT = new BubbleInfluencerRepository( MockBubbleDataHandler );
        }
    }
}
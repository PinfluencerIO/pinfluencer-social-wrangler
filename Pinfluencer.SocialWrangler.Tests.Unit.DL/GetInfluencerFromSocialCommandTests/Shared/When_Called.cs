using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.GetInfluencerFromSocialCommandTests.Shared
{
    public abstract class When_Called : Given_A_GetInfluencerFromSocialCommand
    {
        protected SocialInsightsUser DefaultSocialInsightsUser = new SocialInsightsUser
        {
            Bio = "This is an example",
            Followers = 212,
            Username = "examplehandle",
            Id = "654321",
            Name = "Aidan Gannon"
        };

        protected new SocialInfoUser DefaultSocialInfoUser => new SocialInfoUser
        {
            Age = 21,
            Gender = GenderEnum.Male,
            Id = "123",
            Location = new LocationProperty
            {
                City = "London",
                Country = "United Kingdom",
                CountryCode = CountryEnum.GB
            },
            Name = "Aidan Gannon"
        };

        protected User DefaultUser => new User { Name = "Aidan", Id = "123" };
    }
}
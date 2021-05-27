using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public class FakeSocialInfoUserProps
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public LocationProperty Location { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
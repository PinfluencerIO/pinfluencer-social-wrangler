using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core.Models.User
{
    public class Influencer
    {
        public string SocialUsername { get; set; }
        public User User { get; set; }
        public string Bio { get; set; }
        public LocationProperty Location { get; set; }
        public GenderEnum Gender { get; set; }
        public int Age { get; set; }
    }
}
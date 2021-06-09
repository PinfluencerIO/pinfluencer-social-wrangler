using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core.Models.Social
{
    public class SocialInfoUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public LocationProperty Location { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
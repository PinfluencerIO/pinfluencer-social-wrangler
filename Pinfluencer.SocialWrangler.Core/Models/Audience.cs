using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Core.Models
{
    public class Audience
    {
        public string Id { get; set; }
        public IEnumerable<AudiencePercentage<GenderEnum>> AudienceGender { get; set; }
        public IEnumerable<AudiencePercentage<LocationProperty>> AudienceLocation { get; set; }
        public IEnumerable<AudiencePercentage<AgeProperty>> AudienceAge { get; set; }
        public int Impressions { get; set; }
        public int Reach { get; set; }
        public int Followers { get; set; }
        public double EngagementRate { get; set; }
    }
}
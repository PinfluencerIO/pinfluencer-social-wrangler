using System;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core.Models.Insights
{
    public class GenderAgeProperty
    {
        public GenderEnum Gender { get; set; }

        public Tuple<int, int?> AgeRange { get; set; }
    }
}
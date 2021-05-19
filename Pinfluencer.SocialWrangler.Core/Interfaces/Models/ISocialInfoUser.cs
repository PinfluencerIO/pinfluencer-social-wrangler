using System;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Models
{
    public interface ISocialInfoUser
    {
        public string Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        string Location { get; set; }
        GenderEnum Gender { get; set; }
        DateTime Birthday { set; }
    }
}
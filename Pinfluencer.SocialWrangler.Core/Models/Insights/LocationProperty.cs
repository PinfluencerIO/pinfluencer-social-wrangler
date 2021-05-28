using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Core.Models.Insights
{
    public class LocationProperty
    {
        public CountryEnum CountryCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
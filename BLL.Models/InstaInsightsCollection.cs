using System.Collections.Generic;

namespace BLL.Models
{
    public class InstaInsightsCollection
    {
        public IEnumerable<InstaFollowersInsight<CountryProperty>> FollowersCountries { get; }

        public IEnumerable<InstaFollowersInsight<GenderAgeProperty>> FollowersGenderAges { get; }

        public IEnumerable<InstaImpression> Impressions { get; }

        public InstaInsightsCollection(IEnumerable<InstaFollowersInsight<CountryProperty>> followersCountries, IEnumerable<InstaFollowersInsight<GenderAgeProperty>> followersGenderAges, IEnumerable<InstaImpression> impressions)
        {
            FollowersCountries = followersCountries;
            FollowersGenderAges = followersGenderAges;
            Impressions = impressions;
        }
    }
}
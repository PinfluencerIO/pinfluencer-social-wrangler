using System.Collections.Generic;
using Newtonsoft.Json;

namespace BLL.Models.Insights
{
    public class InstaInsightsCollection
    {
        [JsonProperty("insta_impressions")]
        public IEnumerable<InstaImpression> Impressions { get; }

        public InstaInsightsCollection(IEnumerable<InstaImpression> impressions)
        {
            Impressions = impressions;
        }
    }
}
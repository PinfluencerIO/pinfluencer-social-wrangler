using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BLL.Models.Insights
{
    public class InstaInsightsCollection
    {
        public InstaInsightsCollection(IEnumerable<InstaImpression> impressions)
        {
            Impressions = impressions;
        }

        [JsonPropertyName("insta_impressions")]
        public IEnumerable<InstaImpression> Impressions { get; }
    }
}
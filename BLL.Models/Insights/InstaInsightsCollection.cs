using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BLL.Models.Insights
{
    public class InstaInsightsCollection
    {
        [JsonPropertyName("insta_impressions")]
        public IEnumerable<InstaImpression> Impressions { get; }

        public InstaInsightsCollection(IEnumerable<InstaImpression> impressions)
        {
            Impressions = impressions;
        }
    }
}
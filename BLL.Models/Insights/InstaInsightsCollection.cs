using System.Collections.Generic;

namespace BLL.Models.Insights
{
    public class InstaInsightsCollection
    {
        public IEnumerable<InstaImpression> Impressions { get; }

        public InstaInsightsCollection(IEnumerable<InstaImpression> impressions)
        {
            Impressions = impressions;
        }
    }
}
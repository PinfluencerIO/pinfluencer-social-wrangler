using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pinf.InstaService.Core.Models.Insights
{
    public class InstaInsightsCollection
    {
        public InstaInsightsCollection( IEnumerable<InstaImpression> impressions ) { Impressions = impressions; }

        [ JsonPropertyName( "insta_impressions" ) ]
        public IEnumerable<InstaImpression> Impressions { get; }
    }
}
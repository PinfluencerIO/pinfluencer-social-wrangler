using System;

namespace Pinfluencer.SocialWrangler.Core.Models.Insights
{
    public class ContentImpressions : SocialInsightsBase
    {
        public ContentImpressions( DateTime time, int count )
        {
            Time = time;
            Count = count;
        }

        public ContentImpressions( ) { }
    }
}
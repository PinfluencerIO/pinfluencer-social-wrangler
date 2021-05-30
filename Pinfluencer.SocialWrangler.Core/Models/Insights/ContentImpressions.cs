using System;

namespace Pinfluencer.SocialWrangler.Core.Models.Insights
{
    public class ContentImpressions
    {
        public ContentImpressions( DateTime time, int count )
        {
            Time = time;
            Count = count;
        }

        public ContentImpressions( )
        {
            
        }

        public DateTime Time { get; set; }

        public int Count { get; set; }
    }
}
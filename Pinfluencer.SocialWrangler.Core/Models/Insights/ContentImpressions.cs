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

        public DateTime Time { get; }

        public int Count { get; }
    }
}
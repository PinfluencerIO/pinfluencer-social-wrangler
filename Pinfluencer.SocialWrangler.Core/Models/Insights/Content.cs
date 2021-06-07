using System;

namespace Pinfluencer.SocialWrangler.Core.Models.Insights
{
    public class Content
    {
        public DateTime TimeOfUpload { get; set; }
        public string Id { get; set; }
        public int Engagement { get; set; }
    }
}
using System;
using System.Globalization;
using Newtonsoft.Json;

namespace BLL.Models.Insights
{
    public class InstaImpression
    {
        [JsonProperty("time")]
        public DateTime Time { get; }

        [JsonProperty("count")]
        public int Count { get; }

        public InstaImpression(DateTime time, int count)
        {
            Time = time;
            Count = count;
        }
    }
}
using System;
using System.Globalization;
using Newtonsoft.Json;

namespace BLL.Models.Insights
{
    public class InstaImpression
    {
        [JsonProperty("time")]
        public string Time { get; }

        [JsonProperty("count")]
        public int Count { get; }

        public InstaImpression(DateTime time, int count)
        {
            Time = time.ToString("d");
            Count = count;
        }
    }
}
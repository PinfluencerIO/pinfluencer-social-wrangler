using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BLL.Models.Insights
{
    public class InstaImpression
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; }

        [JsonPropertyName("count")]
        public int Count { get; }

        public InstaImpression(DateTime time, int count)
        {
            Time = time;
            Count = count;
        }
    }
}
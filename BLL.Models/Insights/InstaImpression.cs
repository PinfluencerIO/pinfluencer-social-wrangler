using System;
using System.Text.Json.Serialization;

namespace BLL.Models.Insights
{
    public class InstaImpression
    {
        public InstaImpression(DateTime time, int count)
        {
            Time = time;
            Count = count;
        }

        [JsonPropertyName("time")] public DateTime Time { get; }

        [JsonPropertyName("count")] public int Count { get; }
    }
}
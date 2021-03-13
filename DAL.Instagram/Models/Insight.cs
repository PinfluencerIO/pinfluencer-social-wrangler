using Newtonsoft.Json;

namespace DAL.Instagram.Models
{
    public class Insight
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("end_time")]
        public string Time { get; set; }
    }
}
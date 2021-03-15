using Newtonsoft.Json;

namespace DAL.Instagram.Dtos
{
    public class Insight
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("end_time")]
        public string Time { get; set; }
    }
}
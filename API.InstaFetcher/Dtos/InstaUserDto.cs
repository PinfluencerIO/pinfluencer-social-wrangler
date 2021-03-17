using Newtonsoft.Json;

namespace API.InstaFetcher.Dtos
{
    public class InstaUserDto
    {
        [JsonProperty("user")]
        public string User { get; set; }
    }
}
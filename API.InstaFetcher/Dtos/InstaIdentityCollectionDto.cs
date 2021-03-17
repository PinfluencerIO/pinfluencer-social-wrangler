using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.InstaFetcher.Dtos
{
    public class InstaIdentityCollectionDto
    {
        [JsonProperty("users")]
        public IEnumerable<InsatIdentityDto> InstaUserIdentities { get; set; }

        [JsonProperty("has_multiple")]
        public bool HasMultiple { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty { get; set; }
    }
    
    public class InsatIdentityDto
    {
        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
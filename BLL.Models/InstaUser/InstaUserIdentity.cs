using Newtonsoft.Json;

namespace BLL.Models.InstaUser
{
    public class InstaUserIdentity
    {
        [JsonProperty("handle")]
        public string Handle { get; }

        [JsonProperty("id")]
        public string Id { get; }

        public InstaUserIdentity(string handle, string id)
        {
            Handle = handle;
            Id = id;
        }
    }
}
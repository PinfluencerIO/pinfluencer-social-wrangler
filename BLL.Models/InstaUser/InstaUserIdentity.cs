using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BLL.Models.InstaUser
{
    public class InstaUserIdentity
    {
        [JsonPropertyName("handle")]
        public string Handle { get; }

        [JsonPropertyName("id")]
        public string Id { get; }

        public InstaUserIdentity(string handle, string id)
        {
            Handle = handle;
            Id = id;
        }
    }
}
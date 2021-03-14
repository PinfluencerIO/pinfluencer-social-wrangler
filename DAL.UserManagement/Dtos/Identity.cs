using Newtonsoft.Json;

namespace DAL.UserManagement.Dtos
{
    public class Identity
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DAL.UserManagement.Dtos
{
    public class Auth0User
    {
        [JsonProperty("user_id")]
        public string Id { get; set; }

        [JsonProperty("identities")]
        public IEnumerable<Identity> Identities { get; set; }
    }
}
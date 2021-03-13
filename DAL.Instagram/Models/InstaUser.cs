﻿using Newtonsoft.Json;

namespace DAL.Instagram.Models
{
    public class InstaUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("biography")]
        public string Bio { get; set; }

        [JsonProperty("followers_count")]
        public int Followers { get; set; }
    }
}
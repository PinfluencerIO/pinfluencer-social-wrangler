using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DAL.Instagram.Models
{
    public class DataArray<T>
    {
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
    }
}
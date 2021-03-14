using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DAL.Instagram.Dtos
{
    public class Metric
    {
        [JsonProperty("values")]
        public IEnumerable<Insight> Insights { get; set; }
    }
}
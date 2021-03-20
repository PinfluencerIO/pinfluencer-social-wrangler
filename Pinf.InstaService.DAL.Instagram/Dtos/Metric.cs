using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Instagram.Dtos
{
    public class Metric
    {
        [JsonProperty("values")] public IEnumerable<Insight> Insights { get; set; }
    }
}
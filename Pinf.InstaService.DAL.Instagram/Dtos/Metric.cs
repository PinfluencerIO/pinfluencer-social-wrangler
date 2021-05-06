using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pinf.InstaService.DAL.Instagram.Dtos
{
    [ DataContract ]
    public class Metric<T>
    {
        [ DataMember( Name = "values" ) ] public IEnumerable<Insight<T>> Insights { get; set; }
    }
}
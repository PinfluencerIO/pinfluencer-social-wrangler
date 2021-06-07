using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos
{
    [ DataContract ]
    public class Metric<T>
    {
        [ DataMember( Name = "values" ) ] public IEnumerable<Insight<T>> Insights { get; set; }
    }
}
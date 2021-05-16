using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Dtos
{
    [ DataContract ]
    public class DataArray<T>
    {
        [ DataMember( Name = "data" ) ] public IEnumerable<T> Data { get; set; }
    }
}
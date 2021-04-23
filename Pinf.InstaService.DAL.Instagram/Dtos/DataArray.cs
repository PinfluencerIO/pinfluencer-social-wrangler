using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Instagram.Dtos
{
    public class DataArray<T>
    {
        [ JsonProperty( "data" ) ] public IEnumerable<T> Data { get; set; }
    }
}
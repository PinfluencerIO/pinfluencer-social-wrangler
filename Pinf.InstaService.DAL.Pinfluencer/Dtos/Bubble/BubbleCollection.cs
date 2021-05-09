using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble
{
    public class BubbleCollection<T>
    {
        [ JsonProperty( "results" ) ] public IEnumerable<T> Results { get; set; }
    }
}
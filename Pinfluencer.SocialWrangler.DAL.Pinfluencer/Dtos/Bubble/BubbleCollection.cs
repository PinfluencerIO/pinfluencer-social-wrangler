using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble
{
    public class BubbleCollection<T>
    {
        [ JsonProperty( "results" ) ] public IEnumerable<T> Results { get; set; }
    }
}
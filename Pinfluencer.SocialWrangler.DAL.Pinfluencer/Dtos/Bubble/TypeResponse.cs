using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble
{
    public class TypeResponse<T>
    {
        [ JsonProperty( "response" ) ] public T Type { get; set; }
    }
}
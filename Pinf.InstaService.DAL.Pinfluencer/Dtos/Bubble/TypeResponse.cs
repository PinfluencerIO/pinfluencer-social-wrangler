using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble
{
    public class TypeResponse<T>
    {
        [ JsonProperty( "response" ) ] public T Type { get; set; }
    }
}
using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.UserManagement.Dtos.Bubble
{
    public class TypeResponse<T>
    {
        [ JsonProperty("response") ]
        public T Type { get; set; }
    }
}
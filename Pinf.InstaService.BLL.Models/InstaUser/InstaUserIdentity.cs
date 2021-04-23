using System.Text.Json.Serialization;

namespace Pinf.InstaService.BLL.Models.InstaUser
{
    public class InstaUserIdentity
    {
        public InstaUserIdentity( string handle, string id )
        {
            Handle = handle;
            Id = id;
        }

        [ JsonPropertyName( "handle" ) ] public string Handle { get; }

        [ JsonPropertyName( "id" ) ] public string Id { get; }
    }
}
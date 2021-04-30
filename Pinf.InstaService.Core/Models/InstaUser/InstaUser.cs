using System.Text.Json.Serialization;

namespace Pinf.InstaService.Core.Models.InstaUser
{
    public class InstaUser
    {
        [ JsonPropertyName( "handle" ) ] public string Handle { get; set; }

        [ JsonPropertyName( "id" ) ] public string Id { get; set; }

        [ JsonPropertyName( "name" ) ] public string Name { get; set; }

        [ JsonPropertyName( "bio" ) ] public string Bio { get; set; }

        [ JsonPropertyName( "followers" ) ] public int Followers { get; set; }
    }
}
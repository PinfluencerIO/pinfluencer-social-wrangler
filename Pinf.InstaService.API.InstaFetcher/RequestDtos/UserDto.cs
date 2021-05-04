using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Pinf.InstaService.API.InstaFetcher.Contants;

namespace Pinf.InstaService.API.InstaFetcher.RequestDtos
{
    public class UserDto
    {
        [ JsonPropertyName( MvcConstants.Auth0IdKey ) ]
        public string Auth0Id { get; set; }
        [ JsonPropertyName( "user" ) ]
        public string UserId { get; set; }
    }
}
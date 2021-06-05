using System.Text.Json.Serialization;
using Pinfluencer.SocialWrangler.API.Contants;

namespace Pinfluencer.SocialWrangler.API.RequestDtos
{
    public class UserDto
    {
        [ JsonPropertyName( MvcConstants.Auth0IdKey ) ]
        public string Auth0Id { get; set; }

        [ JsonPropertyName( "user" ) ] public string UserId { get; set; }
    }
}
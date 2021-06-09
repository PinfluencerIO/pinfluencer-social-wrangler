using System.Text.Json.Serialization;
using Pinfluencer.SocialWrangler.API.Core.Constants;

namespace Pinfluencer.SocialWrangler.API.Core.Dtos.Request
{
    public class UserDto
    {
        [ JsonPropertyName( MvcConstants.Auth0IdKey ) ]
        public string Auth0Id { get; set; }

        [ JsonPropertyName( "user" ) ] public string UserId { get; set; }
    }
}
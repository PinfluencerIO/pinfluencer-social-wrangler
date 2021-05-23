using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.DAL.Common.Dtos
{
    public class InstagramUser
    {
        [ JsonProperty( "id" ) ] public string Id { get; set; }

        [ JsonProperty( "username" ) ] public string Username { get; set; }

        [ JsonProperty( "name" ) ] public string Name { get; set; }

        [ JsonProperty( "biography" ) ] public string Bio { get; set; }

        [ JsonProperty( "followers_count" ) ] public int Followers { get; set; }
    }
}
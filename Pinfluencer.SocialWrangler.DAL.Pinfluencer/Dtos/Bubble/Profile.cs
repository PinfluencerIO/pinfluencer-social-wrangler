using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble
{
    public class Profile
    {
        [ JsonProperty( "_id" ) ] public string Id { get; set; }

        public string Name { get; set; }
    }
}
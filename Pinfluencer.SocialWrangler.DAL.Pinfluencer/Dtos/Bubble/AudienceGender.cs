using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble
{
    public class AudienceGender
    {
        public string Audience { get; set; }

        public string Name { get; set; }

        public double Percentage { get; set; }

        [ JsonProperty( "_id" ) ]
        public string Id { get; set; }
    }
}
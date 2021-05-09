using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble
{
    public class AudienceAge
    {
        public string Audience { get; set; }

        public string Range { get; set; }

        public double Percentage { get; set; }

        [ JsonProperty( "_id" ) ]
        public string Id { get; set; }
    }
}
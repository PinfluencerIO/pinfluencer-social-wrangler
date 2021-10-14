using Aidan.Common.Core.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble
{
    public class Influencer
    {
        public string Instagram { get; set; }
        public string Profile { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }

        [ JsonConverter( typeof( StringEnumConverter ) ) ]
        public GenderEnum Gender { get; set; }

        public int Age { get; set; }
    }
}
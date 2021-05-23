using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common
{
    public class Dto
    {
        [ JsonProperty( "id" ) ]
        public string Id { get; set; }
        
        [ JsonProperty( "name" ) ]
        public string Value { get; set; }
    }
}
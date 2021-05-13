using System;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.DAL.Common.Dtos
{
    public class FacebookUser
    {
        [ JsonProperty( "location" ) ] public FacebookPage Location { get; set; }
        [ JsonProperty( "birthday" ) ] public DateTime Birthday { get; set; }
        [ JsonProperty( "gender" ) ] public GenderEnum Gender { get; set; }
    }
}
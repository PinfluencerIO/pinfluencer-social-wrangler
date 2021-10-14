using System;
using Aidan.Common.Core.Enum;
using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.DAL.Common.Dtos
{
    public class FacebookUser
    {
        [ JsonProperty( "name" ) ] public string Name { get; set; }
        [ JsonProperty( "id" ) ] public string Id { get; set; }
        [ JsonProperty( "location" ) ] public FacebookPage Location { get; set; }
        [ JsonProperty( "birthday" ) ] public DateTime Birthday { get; set; }
        [ JsonProperty( "gender" ) ] public GenderEnum Gender { get; set; }
    }
}
using System;
using Newtonsoft.Json;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.DAL.Common.Dtos
{
    public class FacebookUser
    {
        [ JsonProperty( "location" ) ] public FacebookPage Location { get; set; }
        [ JsonProperty( "birthday" ) ] public DateTime Birthday { get; set; }
        [ JsonProperty( "gender" ) ] public GenderEnum Gender { get; set; }
    }
}
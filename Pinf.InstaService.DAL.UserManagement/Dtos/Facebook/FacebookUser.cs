using System;
using Newtonsoft.Json;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.DAL.Common.Dtos;

namespace Pinf.InstaService.DAL.UserManagement.Dtos.Facebook
{
    public class FacebookUser
    {
        [ JsonProperty( "location" ) ] public FacebookPage Location { get; set; }
        [ JsonProperty( "birthday" ) ] public DateTime Birthday { get; set; }
        [ JsonProperty( "gender" ) ] public GenderEnum Gender { get; set; }
    }
}
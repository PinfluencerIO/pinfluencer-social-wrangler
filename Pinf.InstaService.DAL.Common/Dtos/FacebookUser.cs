using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.DAL.Common.Dtos
{
    [ DataContract ]
    public class FacebookUser
    {
        [ DataMember( Name = "location" ) ] public FacebookPage Location { get; set; }
        [ DataMember( Name = "birthday" ) ] public string Birthday { get; set; }
        [ DataMember( Name = "gender" ) ] public string Gender { get; set; }
    }
}
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Common.Dtos
{
    [ DataContract ]
    public class FacebookPage
    {
        [ DataMember( Name = "instagram_business_account", IsRequired = false ) ] public InstaUser Insta { get; set; }
        [ DataMember( Name = "id" ) ] public string Id { get; set; }
        [ DataMember( Name = "name" ) ] public string Name { get; set; }
    }
}
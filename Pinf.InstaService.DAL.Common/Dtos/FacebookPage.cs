using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Common.Dtos
{
    public class FacebookPage
    {
        [ JsonProperty( "instagram_business_account" ) ] public InstaUser Insta { get; set; }
        [ JsonProperty( "id" ) ] public string Id { get; set; }
        [ JsonProperty( "name" ) ] public string Name { get; set; }
    }
}
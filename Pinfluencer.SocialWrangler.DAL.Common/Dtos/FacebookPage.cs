using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.DAL.Common.Dtos
{
    public class FacebookPage
    {
        [ JsonProperty( "instagram_business_account" ) ] public InstaUser Insta { get; set; }
        [ JsonProperty( "id" ) ] public string Id { get; set; }
        [ JsonProperty( "name" ) ] public string Name { get; set; }
    }
}
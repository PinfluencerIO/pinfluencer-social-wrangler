using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Instagram.Dtos
{
    public class FacebookPage
    {
        [JsonProperty("instagram_business_account")]
        public InstaUser Insta { get; set; }
    }
}
using Facebook;
using Newtonsoft.Json;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.DAL.Instagram
{
    public class FacebookContext
    {
        public FacebookClient FacebookClient { set; get; }

        public string Get(string url, string fields)
        {
            return JsonConvert.SerializeObject(FacebookClient.Get(url, new RequestFields
            {
                fields = fields
            }));
        }

        public string Get<T>(string url, T parameters)
        {
            return JsonConvert.SerializeObject(FacebookClient.Get(url, parameters));
        }
    }
}
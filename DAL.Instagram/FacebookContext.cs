using DAL.Instagram.Dtos;
using Facebook;
using Newtonsoft.Json;

namespace DAL.Instagram
{
    public class FacebookContext
    {
        public FacebookClient FacebookClient { set; get; }

        public string Get(string url, string fields)
        {
            return JsonConvert.SerializeObject(FacebookClient.Get(url,new RequestFields
            {
                fields=fields
            }));
        }
        
        public string Get<T>(string url, T parameters)
        {
            return JsonConvert.SerializeObject(FacebookClient.Get(url,parameters));
        }
    }
}
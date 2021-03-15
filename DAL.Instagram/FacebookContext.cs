using DAL.Instagram.Dtos;
using Facebook;
using Newtonsoft.Json;

namespace DAL.Instagram
{
    public class FacebookContext
    {
        private readonly FacebookClient _facebookClient;

        public FacebookContext(FacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public string Get(string url, string fields)
        {
            return JsonConvert.SerializeObject(_facebookClient.Get(url,new RequestFields
            {
                fields=fields
            }));
        }
        
        public string Get<T>(string url, T parameters)
        {
            return JsonConvert.SerializeObject(_facebookClient.Get(url,parameters));
        }
    }
}
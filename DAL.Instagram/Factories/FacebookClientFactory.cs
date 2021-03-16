using Bootstrapping.Services.Factories;
using Facebook;

namespace DAL.Instagram.Factories
{
    public class FacebookClientFactory : IFacebookClientFactory
    {
        public FacebookClient Get(string token)
        {
            return new FacebookClient(token);
        }
    }
}
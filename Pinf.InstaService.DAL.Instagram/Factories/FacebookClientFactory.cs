using Pinf.InstaService.Bootstrapping.Services.Factories;
using Facebook;

namespace Pinf.InstaService.DAL.Instagram.Factories
{
    public class FacebookClientFactory : IFacebookClientFactory
    {
        public FacebookClient Get(string token)
        {
            return new FacebookClient(token);
        }
    }
}
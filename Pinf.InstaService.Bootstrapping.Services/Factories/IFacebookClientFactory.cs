using Facebook;

namespace Pinf.InstaService.Bootstrapping.Services.Factories
{
    public interface IFacebookClientFactory
    {
        public FacebookClient Get(string token);
    }
}
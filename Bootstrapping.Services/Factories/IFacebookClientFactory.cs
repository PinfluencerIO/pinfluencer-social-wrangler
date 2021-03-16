using Facebook;

namespace Bootstrapping.Services.Factories
{
    public interface IFacebookClientFactory
    {
        public FacebookClient Get(string token);
    }
}
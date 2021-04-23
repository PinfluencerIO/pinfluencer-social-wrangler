using Facebook;

namespace Pinf.InstaService.BLL.Core.Factories
{
    public interface IFacebookClientFactory
    {
        public FacebookClient Get(string token);
    }
}
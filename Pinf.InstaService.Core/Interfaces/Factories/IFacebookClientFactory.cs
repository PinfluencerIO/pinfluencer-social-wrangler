using Facebook;

namespace Pinf.InstaService.Core.Interfaces.Factories
{
    public interface IFacebookClientFactory
    {
        public FacebookClient Get( string token );
    }
}
using Facebook;

namespace Pinf.InstaService.DAL.Core.Interfaces.Factories
{
    public interface IFacebookClientFactory
    {
        public FacebookClient Get( string token );
    }
}
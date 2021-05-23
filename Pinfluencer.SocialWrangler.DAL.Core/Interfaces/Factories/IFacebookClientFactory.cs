using Facebook;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories
{
    public interface IFacebookClientFactory
    {
        public IFacebookClientAdapter Get( string token );
    }
}
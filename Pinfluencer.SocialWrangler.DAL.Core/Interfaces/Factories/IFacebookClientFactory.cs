using Facebook;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories
{
    public interface IFacebookClientFactory
    {
        public FacebookClient Get( string token );
    }
}
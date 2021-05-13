using Facebook;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories;

namespace Pinfluencer.SocialWrangler.DAL.Instagram.Factories
{
    public class FacebookClientFactory : IFacebookClientFactory
    {
        public FacebookClient Get( string token ) { return new FacebookClient( token ); }
    }
}
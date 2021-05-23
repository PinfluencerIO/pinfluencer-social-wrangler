using Facebook;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Factories
{
    public class FacebookClientFactory : IFacebookClientFactory
    {
        public IFacebookClientAdapter Get( string token ) { return new FacebookClientAdapter( token ); }
    }
}
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Factories
{
    public class FacebookClientFactory : IFacebookClientFactory
    {
        public IFacebookClientAdapter Factory( string token ) { return new FacebookClientAdapter( token ); }
    }
}
using Facebook;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories;
using Pinfluencer.SocialWrangler.DAL.Common;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Factories
{
    public class FacebookClientFactory : IFacebookClientFactory
    {
        public IFacebookClientAdapter Factory( string token ) { return new FacebookClientAdapter( token ); }
    }
}
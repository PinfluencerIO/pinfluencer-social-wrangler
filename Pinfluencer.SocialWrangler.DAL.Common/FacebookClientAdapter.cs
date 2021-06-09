using Facebook;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Common
{
    public class FacebookClientAdapter : IFacebookClientAdapter
    {
        private readonly FacebookClient _facebookClient;

        public FacebookClientAdapter( string token ) { _facebookClient = new FacebookClient( token ); }

        public object Get( string path, object parameters ) { return _facebookClient.Get( path, parameters ); }
    }
}
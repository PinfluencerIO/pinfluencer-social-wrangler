using Facebook;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Common
{
    public class FacebookClientAdapter : IFacebookClientAdapter
    {
        private readonly FacebookClient _facebookClient;

        public FacebookClientAdapter( )
        {
            _facebookClient = new FacebookClient( );
        }
        
        public FacebookClientAdapter( string token )
        {
            _facebookClient = new FacebookClient( token );
        }

        public object Get( string path, object parameters ) => _facebookClient.Get( path, parameters );

    }
}
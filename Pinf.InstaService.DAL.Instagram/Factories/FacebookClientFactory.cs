using Facebook;
using Pinf.InstaService.Core.Interfaces.Factories;

namespace Pinf.InstaService.DAL.Instagram.Factories
{
    public class FacebookClientFactory : IFacebookClientFactory
    {
        public FacebookClient Get( string token ) { return new FacebookClient( token ); }
    }
}
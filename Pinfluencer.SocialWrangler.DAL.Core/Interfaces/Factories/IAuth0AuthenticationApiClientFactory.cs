using Auth0.AuthenticationApi;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories
{
    public interface IAuth0AuthenticationApiClientFactory
    {
        public IAuthenticationApiClient Get( );
    }
}
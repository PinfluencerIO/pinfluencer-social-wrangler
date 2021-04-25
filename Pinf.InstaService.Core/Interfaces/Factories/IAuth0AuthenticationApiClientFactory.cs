using Auth0.AuthenticationApi;

namespace Pinf.InstaService.Core.Interfaces.Factories
{
    public interface IAuth0AuthenticationApiClientFactory
    {
        public IAuthenticationApiClient Get( );
    }
}
using Auth0.AuthenticationApi;

namespace Pinf.InstaService.DAL.Core.Interfaces.Factories
{
    public interface IAuth0AuthenticationApiClientFactory
    {
        public IAuthenticationApiClient Get( );
    }
}
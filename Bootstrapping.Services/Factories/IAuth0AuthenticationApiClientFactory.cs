using Auth0.AuthenticationApi;

namespace Bootstrapping.Services.Factories
{
    public interface IAuth0AuthenticationApiClientFactory
    {
        public IAuthenticationApiClient Get();
    }
}
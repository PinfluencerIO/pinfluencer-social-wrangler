using Auth0.AuthenticationApi;

namespace Pinf.InstaService.Bootstrapping.Services.Factories
{
    public interface IAuth0AuthenticationApiClientFactory
    {
        public IAuthenticationApiClient Get();
    }
}
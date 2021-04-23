using Auth0.AuthenticationApi;

namespace Pinf.InstaService.BLL.Core.Factories
{
    public interface IAuth0AuthenticationApiClientFactory
    {
        public IAuthenticationApiClient Get();
    }
}
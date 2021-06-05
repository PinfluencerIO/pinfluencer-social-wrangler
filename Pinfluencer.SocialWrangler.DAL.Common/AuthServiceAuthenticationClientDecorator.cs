using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.Extensions.Configuration;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Options;

namespace Pinfluencer.SocialWrangler.DAL.Common
{
    class AuthServiceAuthenticationClientDecorator : IAuthServiceAuthenticationClientDecorator
    {
        private readonly IAuthenticationApiClient _authenticationApiClient;

        public AuthServiceAuthenticationClientDecorator( string domain )
        {
            _authenticationApiClient = new AuthenticationApiClient( domain, new HttpClientAuthenticationConnection(  ) );
        }

        public string GetToken( ( string clientId, string clientSecret, string audience ) authSettings )
        {
            var ( clientId, clientSecret, audience ) = authSettings;
            return _authenticationApiClient
                .GetTokenAsync( new ClientCredentialsTokenRequest
                {
                    ClientId =  clientId,
                    ClientSecret = clientSecret,
                    Audience = audience
                } ).Result.AccessToken;
        }
    }
}
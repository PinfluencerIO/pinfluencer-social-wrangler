using System;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.Extensions.Configuration;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Common
{
    public class Auth0AuthenticationClientDecorator : IAuthServiceAuthenticationClientDecorator
    {
        private readonly IAuthenticationApiClient _authenticationApiClient;

        public Auth0AuthenticationClientDecorator( string domain )
        {
            _authenticationApiClient = new AuthenticationApiClient( domain, new HttpClientAuthenticationConnection(  ) );
        }

        public string GetToken( ( string clientId, string clientSecret, string audience ) authSettings )
        {
            try
            {
                var (clientId, clientSecret, audience) = authSettings;
                return _authenticationApiClient
                    .GetTokenAsync( new ClientCredentialsTokenRequest
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret,
                        Audience = audience
                    } ).Result.AccessToken;
            }
            catch( AggregateException e )
            {
                throw e.InnerException;
            }
        }
    }
}
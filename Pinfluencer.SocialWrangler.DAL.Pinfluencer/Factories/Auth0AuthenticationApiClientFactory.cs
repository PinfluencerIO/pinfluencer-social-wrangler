using System;
using Auth0.AuthenticationApi;
using Microsoft.Extensions.Configuration;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Factories
{
    public class Auth0AuthenticationApiClientFactory : IAuth0AuthenticationApiClientFactory
    {
        private readonly IConfiguration _configuration;

        public Auth0AuthenticationApiClientFactory( IConfiguration configuration ) { _configuration = configuration; }

        public IAuthenticationApiClient Get( ) { throw new NotImplementedException( ); }
    }
}
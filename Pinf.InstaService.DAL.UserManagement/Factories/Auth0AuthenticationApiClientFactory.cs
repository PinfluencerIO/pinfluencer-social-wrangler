using System;
using Auth0.AuthenticationApi;
using Microsoft.Extensions.Configuration;
using Pinf.InstaService.BLL.Core.Factories;

namespace Pinf.InstaService.DAL.UserManagement.Factories
{
    public class Auth0AuthenticationApiClientFactory : IAuth0AuthenticationApiClientFactory
    {
        private readonly IConfiguration _configuration;

        public Auth0AuthenticationApiClientFactory( IConfiguration configuration ) { _configuration = configuration; }

        public IAuthenticationApiClient Get( ) { throw new NotImplementedException( ); }
    }
}
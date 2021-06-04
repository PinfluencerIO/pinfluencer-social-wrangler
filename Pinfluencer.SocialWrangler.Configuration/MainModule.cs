using System.Collections;
using System.Linq;
using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common;

namespace Pinfluencer.SocialWrangler.Configuration
{
    public static class MainModule
    {
        public static IServiceCollection BindSocialWrangler( this IServiceCollection services )
        {
            return ModuleExtensions
                .GetMainServiceCollection( services )
                .AddScoped<Auth0Context>( )
                .AddTransient<IManagementConnection, HttpClientManagementConnection>( )
                .AddTransient<IAuthenticationConnection, HttpClientAuthenticationConnection>( );
        }
    }
}
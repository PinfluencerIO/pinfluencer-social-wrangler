using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;

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
using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;

namespace Pinfluencer.SocialWrangler.Configuration
{
    public static class MainModule
    {
        public static IServiceCollection BindApplicationServices( this IServiceCollection services )
        {
            return ModuleExtensions
                .GetMainServiceCollection( services );
        }
    }
}
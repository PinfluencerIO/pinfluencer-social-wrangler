using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.BLL;
using Pinfluencer.SocialWrangler.Core;

namespace Pinfluencer.SocialWrangler.Configuration
{
    public static class BuisnessLayerModule
    {
        [ Binding ]
        public static IServiceCollection Bind( IServiceCollection services )
        {
            MainInitializer.Initialize( );
            BllInitializer.Initialize( );
            return services;
        }
    }
}
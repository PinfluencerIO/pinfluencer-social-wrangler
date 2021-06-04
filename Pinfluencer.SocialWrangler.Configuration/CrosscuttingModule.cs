using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.Crosscutting.Web;

namespace Pinfluencer.SocialWrangler.Configuration
{
    public static class CrosscuttingModule
    {
        [ Binding ]
        public static IServiceCollection Bind( IServiceCollection services )
        {
            MainInitializer.Initialize( );
            UtilsInitializer.Initialize( );
            WebUtilsInitializer.Initialize( );
            return services;
        }
    }
}
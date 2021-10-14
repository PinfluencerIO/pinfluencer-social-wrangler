using Microsoft.Extensions.DependencyInjection;

namespace Pinfluencer.SocialWrangler.UI.DIModule
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection BindPresentationLayer( this IServiceCollection serviceCollection ) => serviceCollection;
    }
}
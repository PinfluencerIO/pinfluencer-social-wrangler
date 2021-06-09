using System;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Configuration;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DL.Core;

namespace Pinfluencer.SocialWrangler.DL.DIModule
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection BindDomainLayer( this IServiceCollection serviceCollection ) =>
            serviceCollection.BindServices( ApplicationLayerEnum.DL, new Action[]
            {
                BllInitializer.Initialize,
                BllCoreInitializer.Initialize
            } );
    }
}
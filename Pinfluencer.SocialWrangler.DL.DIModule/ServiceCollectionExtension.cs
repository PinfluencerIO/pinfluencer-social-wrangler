using System;
using Aidan.Common.Core.Enum;
using Aidan.Common.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Core.Constants;
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
            }, WranglerApplicationConstants.RootNamespace );
    }
}
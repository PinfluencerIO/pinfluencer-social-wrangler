using System;
using Aidan.Common.Core;
using Aidan.Common.DependencyInjection;
using Aidan.Common.Utils;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Core.Constants;

namespace Pinfluencer.SocialWrangler.Crosscutting.DIModule
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection BindCrosscuttingLayer( this IServiceCollection serviceCollection ) =>
            serviceCollection.BindServices( new Action[]
            {
                CommonUtilsInitializer.Initialize,
                CommonInitializer.Initialize
            }, WranglerApplicationConstants.CommonRootNamespace );
    }
}
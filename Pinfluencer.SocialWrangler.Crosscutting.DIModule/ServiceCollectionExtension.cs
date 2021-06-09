using System;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Configuration;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Crosscutting.Core;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.Crosscutting.Web;

namespace Pinfluencer.SocialWrangler.Crosscutting.DIModule
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection BindCrosscuttingLayer( this IServiceCollection serviceCollection ) =>
            serviceCollection.BindServices( ApplicationLayerEnum.Crosscutting, new Action[]
            {
                UtilsCoreInitializer.Initialize,
                UtilsInitializer.Initialize,
                WebUtilsInitializer.Initialize
            } );
    }
}
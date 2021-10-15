using System;
using Aidan.Common.Core.Enum;
using Aidan.Common.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Core.Constants;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Core;
using Pinfluencer.SocialWrangler.DAL.Facebook;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;

namespace Pinfluencer.SocialWrangler.DAL.DIModule
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection BindDataAcessLayer( this IServiceCollection serviceCollection ) =>
            serviceCollection.BindServices( ApplicationLayerEnum.DAL, new Action[]
            {
                DalCoreInitializer.Initialize,
                DalUtilsInitializer.Initialize,
                DalFacebookInitializer.Initialize,
                DalPinfluencerInitializer.Initialize
            }, WranglerApplicationConstants.RootNamespace );
    }
}
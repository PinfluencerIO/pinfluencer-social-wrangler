using System;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions
{
    public static class AddFactoryServiceCollectionExtensions
    {
        private static IServiceCollection AddFactory( this IServiceCollection sc, Type factory,
            ServiceLifetime serviceLifetime = ServiceLifetime.Singleton, params Assembly [ ] scanAssemblies )
        {
            var facClsBuilder = FactoryClassBuilder.CreateFactoryClassBuilder( sc, factory );

            sc.Add( new ServiceDescriptor( factory, sp =>
            {
                var facType = IlFactoryTypeCreator.CreateType( facClsBuilder, factory );
                return FactoryTypeActivator.Activate( sp, facType );
            }, serviceLifetime ) );

            return sc;
        }

        public static IServiceCollection AddFactory( this IServiceCollection sc, Type factory,
            ServiceLifetime serviceLifetime = ServiceLifetime.Singleton )
        {
            return AddFactory( sc, factory, serviceLifetime, factory.Assembly );
        }

        public static IServiceCollection Replace<TService>( this IServiceCollection sc,
            Func<IServiceProvider, TService> implementationFactory ) where TService : class => 
            sc.Replace( new ServiceDescriptor( typeof( TService ), sc ) );
    }
}
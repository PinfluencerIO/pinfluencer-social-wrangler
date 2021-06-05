using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions
{
    public static class AddFactoryServiceCollectionExtensions
    {
        public static IServiceCollection AddFactory( this IServiceCollection sc, Type factory,
            ServiceLifetime serviceLifetime = ServiceLifetime.Singleton )
        {
            var facClsBuilder = FactoryClassBuilder.CreateFactoryClassBuilder( sc, factory );

            sc.Add( new ServiceDescriptor( factory, sp =>
            {
                var facType = IlFactoryTypeCreator.CreateType( facClsBuilder, factory );
                var factoryGeneratedService = FactoryTypeActivator.Activate( sp, facType );
                return factoryGeneratedService;
            }, serviceLifetime ) );

            return sc;
        }

        public static IServiceCollection Replace( this IServiceCollection sc,
            Func<IServiceProvider, object> implementationFactory, Type serviceType )
        {
            if( sc == null ) throw new ArgumentNullException( nameof( sc ) );

            var lifetime = ServiceLifetime.Transient;
            // Remove existing
            var count = sc.Count;
            for( var i = 0; i < count; i++ )
            {
                var service = sc[ i ];
                if( service.ServiceType != serviceType ) continue;
                lifetime = service.Lifetime;
                sc.RemoveAt( i );
                break;
            }

            switch( lifetime )
            {
                case ServiceLifetime.Scoped:
                    sc.AddScoped( serviceType, implementationFactory );
                    break;
                case ServiceLifetime.Transient:
                    sc.AddTransient( serviceType, implementationFactory );
                    break;
                case ServiceLifetime.Singleton:
                    sc.AddSingleton( serviceType, implementationFactory );
                    break;
            }

            return sc;
        }
    }
}
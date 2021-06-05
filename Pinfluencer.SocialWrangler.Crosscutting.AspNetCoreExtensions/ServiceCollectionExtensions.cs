using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

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
            Func<IServiceProvider, TService> implementationFactory ) where TService : class
        {
            if( sc == null ) throw new ArgumentNullException( nameof( sc ) );

            var lifetime = ServiceLifetime.Transient;
            // Remove existing
            var count = sc.Count;
            for( var i = 0; i < count; i++ )
            {
                var service = sc[ i ];
                if( service.ServiceType != typeof( TService ) ) continue;
                lifetime = service.Lifetime;
                sc.RemoveAt( i );
                break;
            }

            switch( lifetime )
            {
                case ServiceLifetime.Scoped:
                    sc.AddScoped( implementationFactory );
                    break;
                case ServiceLifetime.Transient:
                    sc.AddTransient( implementationFactory );
                    break;
                case ServiceLifetime.Singleton:
                    sc.AddSingleton( implementationFactory );
                    break;
            }

            return sc;
        }
    }
}
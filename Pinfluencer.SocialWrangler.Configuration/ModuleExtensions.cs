using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Core.Attributes;
using Pinfluencer.SocialWrangler.Core.Constants;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces;
using Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions;

namespace Pinfluencer.SocialWrangler.Configuration
{
    public static class ModuleExtensions
    {
        private static IServiceCollection Bind( IServiceCollection services, Type [ ] types, string layer )
        {
            RegisterServices( services, GetServiceTypes( GetInterfaces( types, layer ), types ) );
            RegisterFactories( services, GetFactories( GetInterfaces( types, layer ) ) );
            return services;
        }

        private static void RegisterFactories( IServiceCollection services, Type [ ] factories )
        {
            foreach( var factory in factories ) services.AddFactory( factory );
        }

        private static void RegisterServices( IServiceCollection services,
            List<((Type contract, ServiceLifetime scope), Type implementation)> serviceTypes )
        {
            foreach( var ((contract, scope), implementation) in serviceTypes )
                services.Add( new ServiceDescriptor( contract, implementation, scope ) );
        }

        private static List<((Type contract, ServiceLifetime scope), Type implementation)> GetServiceTypes(
            Type [ ] interfaces, Type [ ] types )
        {
            var serviceTypes = new List<((Type contract, ServiceLifetime scope), Type implementation)>( );
            foreach( var iInterface in interfaces )
            {
                var lifetime = ServiceLifetime.Transient;
                try { AddService( types, iInterface, lifetime, serviceTypes ); }
                catch( Exception )
                {
                    // service not found
                }
            }

            return serviceTypes;
        }

        private static void AddService( Type [ ] types, Type iInterface, ServiceLifetime lifetime,
            List<((Type contract, ServiceLifetime scope), Type implementation)> serviceTypes )
        {
            var service = types
                .First( x =>
                    x.GetInterfaces( ).Any( type =>
                        $"{type.Namespace}.{type.Name}" == $"{iInterface.Namespace}.{iInterface.Name}" ) &&
                    x.IsClass );
            try
            {
                var serviceAttribute = iInterface
                    .GetCustomAttributes<ServiceAttribute>( )
                    .First( );
                lifetime = GetServiceLifetime( serviceAttribute, lifetime );
            }
            catch( Exception )
            {
                // service does not have custom scope
            }

            serviceTypes
                .Add( ( ( iInterface, lifetime ), service ) );
        }

        private static ServiceLifetime GetServiceLifetime( ServiceAttribute serviceAttribute, ServiceLifetime lifetime )
        {
            switch( serviceAttribute.Scope )
            {
                case ServiceLifetimeEnum.Scoped:
                    lifetime = ServiceLifetime.Scoped;
                    break;
                case ServiceLifetimeEnum.Singleton:
                    lifetime = ServiceLifetime.Singleton;
                    break;
                case ServiceLifetimeEnum.Transient:
                    lifetime = ServiceLifetime.Transient;
                    break;
            }

            return lifetime;
        }

        private static Type [ ] GetFactories( Type [ ] interfaces )
        {
            var factories = interfaces
                .Where( x => x.GetInterfaces( ).Any( subType => subType == typeof( IFactory ) ) )
                .ToArray( );
            return factories;
        }

        private static Type [ ] GetInterfaces( Type [ ] types, string layer )
        {
            var interfaces = types
                .Where( type =>
                {
                    try
                    {
                        return type.Namespace.Contains( $"{ApplicationConstants.RootNamespace}.{layer}.{ApplicationConstants.ContractNamespace}" ) &&
                               type.IsInterface;
                    }
                    catch( Exception ) { return false; }
                } )
                .ToArray( );
            return interfaces;
        }

        public static Type [ ] GetTypes( string layer )
        {
            var types = AppDomain
                .CurrentDomain
                .GetAssemblies( )
                .SelectMany( x => x.GetTypes( ) )
                .Where( x =>
                {
                    try { return x.Namespace.Contains( $"{ApplicationConstants.RootNamespace}.{layer}" ); }
                    catch( Exception ) { return false; }
                } )
                .ToArray( );
            return types;
        }

        public static IServiceCollection BindServices( this IServiceCollection serviceCollection, ApplicationLayerEnum applicationLayer, Action[] initializers ) => 
            Bind( serviceCollection, GetTypes( applicationLayer.ToString( ) ), applicationLayer.ToString( ) );
    }
}
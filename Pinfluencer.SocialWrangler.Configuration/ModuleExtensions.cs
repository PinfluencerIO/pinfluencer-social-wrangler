using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Attributes;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions;

namespace Pinfluencer.SocialWrangler.Configuration
{
    public static class ModuleExtensions
    {
        private const string RootNamespace = "Pinfluencer.SocialWrangler";
        private const string ContractNamespace = "Core.Interfaces.Contract";

        public static IServiceCollection Bind( IServiceCollection services, Type [ ] types )
        {
            RegisterServices( services, GetServiceTypes( GetInterfaces( types ), types ) );
            RegisterFactories( services, GetFactories( GetInterfaces( types ) ) );
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

        private static Type [ ] GetInterfaces( Type [ ] types )
        {
            var interfaces = types
                .Where( type =>
                {
                    try
                    {
                        return type.Namespace.Contains( $"{RootNamespace}.{ContractNamespace}" ) &&
                               type.IsInterface;
                    }
                    catch( Exception ) { return false; }
                } )
                .ToArray( );
            return interfaces;
        }

        public static Type [ ] GetTypes( )
        {
            var types = AppDomain
                .CurrentDomain
                .GetAssemblies( )
                .SelectMany( x => x.GetTypes( ) )
                .Where( x =>
                {
                    try { return x.Namespace.Contains( $"{RootNamespace}" ); }
                    catch( Exception ) { return false; }
                } )
                .ToArray( );
            return types;
        }

        public static IServiceCollection GetMainServiceCollection( IServiceCollection services )
        {
            var methods = GetTypes( )
                .SelectMany( x => x
                    .GetMethods( )
                    .Where( y => y
                        .GetCustomAttributes( false )
                        .Any( z => z
                            .GetType( ) == typeof( BindingAttribute ) ) ) )
                .Where( x => x != null );
            foreach( var method in methods )
                services = method?
                    .Invoke( null, new object [ ] { services } ) as IServiceCollection;
            return Bind( services, GetTypes( ) );
        }
    }
}
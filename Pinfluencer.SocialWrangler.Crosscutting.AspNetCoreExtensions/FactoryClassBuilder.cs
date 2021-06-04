using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions.Exceptions;
using Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions.Models;

namespace Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions
{
    /// <summary>
    ///     Factory type interface structure for type validation and preparation for the IL type build
    /// </summary>
    internal class FactoryClassBuilder
    {
        private FactoryClassBuilder( ) { }

        /// <summary>
        ///     Private readonly fields that should be generated inside the factory type
        /// </summary>
        public List<FactoryClassReadOnlyField> PrivateReadonlyFields { get; } = new List<FactoryClassReadOnlyField>( );

        /// <summary>
        ///     Factory methods that should be generated inside the factory type
        /// </summary>
        public List<FactoryClassMethod> FactoryMethods { get; } = new List<FactoryClassMethod>( );

        /// <summary>
        ///     Constructs the <see cref="FactoryClassBuilder" /> structure for later
        ///     processing of the <see cref="IlFactoryTypeCreator" />.
        /// </summary>
        /// <typeparam name="TFactory">Type of the factory interface</typeparam>
        /// <param name="assemblies">Assemblies to scan for implemented return types</param>
        /// <returns>New instance of <see cref="FactoryClassBuilder" /></returns>
        public static FactoryClassBuilder CreateFactoryClassBuilder<TFactory>( ServiceDescriptor [ ] assemblies )
        {
            return CreateFactoryClassBuilder( assemblies, typeof( TFactory ) );
        }

        public static FactoryClassBuilder CreateFactoryClassBuilder( IEnumerable<ServiceDescriptor> assemblies, Type factory )
        {
            var facClsBuilder = new FactoryClassBuilder( );
            var allTypes = assemblies.SelectMany( t => new [] { t.ImplementationType, t.ServiceType } );
            var factoryMethods = factory.GetMethods( ).Where( m => m.Name == "Factory" );

            foreach( var factoryMethod in factoryMethods )
            {
                var factoryParams = factoryMethod.GetParameters( );
                var debugName =
                    $"{factoryMethod.DeclaringType?.Name}.{factoryMethod.Name}({string.Join( ",", factoryParams.Select( p => p.ParameterType.Name ) )})";

                var interfaceReturnType = factoryMethod.ReturnType;
                if( !interfaceReturnType.IsInterface )
                    throw new FactoryMethodNotInterfaceException(
                        $"Factory method '{debugName}' return type must be an interface" );

                var implementedTypes = allTypes
                    .Where( t => interfaceReturnType.IsAssignableFrom( t ) && !t.IsInterface ).ToList( );

                if( implementedTypes.Count == 0 )
                    throw new NoImplementingClassFoundException(
                        $"No class implementing interface {interfaceReturnType.Name} found" );

                var foundCtors = implementedTypes
                    .First( )
                    .GetConstructors( )
                    .ToList( );

                var connectibleCtors = foundCtors.FindAll( fctor =>
                {
                    var fctorParams = fctor.GetParameters( );

                    // no match if there are more factory method params than ctor params
                    if( fctorParams.Length < factoryParams.Length )
                        return false;

                    // no match if there is type mismatch at same parameter position
                    for( var i = 0; i < factoryParams.Length; i++ )
                        if( fctorParams[ i ].ParameterType != factoryParams[ i ].ParameterType )
                            return false;

                    // for parameter positions AFTER all factory parameters,
                    // simple value type (ints, strings, enums, etc.) are not allowed 
                    // as it would result into an attempt to inject this type
                    // which is definitely not the right thing to do
                    for( var i = factoryParams.Length; i < fctorParams.Length; i++ )
                        if( fctorParams[ i ].ParameterType.IsSimple( ) )
                            return false;

                    //otherwise it is a match
                    return true;
                } );

                if( connectibleCtors.Count == 0 )
                    throw new NoValidCtorFoundException(
                        $"No valid constructors were found for factory method '{debugName}'. At least one constructor must match the factory parameters." );

                if( connectibleCtors.Count > 1 )
                    throw new ConflictingCtorsFoundException(
                        $"There is more than one constructor for factory method '{debugName}'. Only one constructor is permitted." );

                var ctor = connectibleCtors.Single( );
                var ctorParams = ctor.GetParameters( );

                var facCtorParameters = new List<FactoryClassMethodOrFieldParameter>( );

                for( var i = 0; i < ctorParams.Length; i++ )
                {
                    var fromField = i > factoryParams.Length - 1;
                    var isFactoryReinjection = ctorParams[ i ].ParameterType == factory;

                    var fieldName = $"field_{ctorParams[ i ].ParameterType.Name}";
                    var methodParamName = $"param_{i}_{ctorParams[ i ].ParameterType.Name}";

                    if( isFactoryReinjection )
                        fromField = false;

                    if( fromField && !facClsBuilder.PrivateReadonlyFields.Any( f => f.Name == fieldName ) )
                        facClsBuilder.PrivateReadonlyFields.Add( new FactoryClassReadOnlyField
                        {
                            Name = fieldName,
                            Type = ctorParams[ i ].ParameterType
                        } );

                    facCtorParameters.Add( new FactoryClassMethodOrFieldParameter
                    {
                        IsFromField = fromField,
                        IsFactoryReinjection = isFactoryReinjection,
                        MatchingField = fieldName,
                        Type = ctorParams[ i ].ParameterType
                    } );
                }

                facClsBuilder.FactoryMethods.Add( new FactoryClassMethod
                {
                    MatchingCtor = ctor,
                    Parameters = facCtorParameters,
                    FactoryInterfaceMethodInfo = factoryMethod
                } );
            }

            return facClsBuilder;
        }
    }
}
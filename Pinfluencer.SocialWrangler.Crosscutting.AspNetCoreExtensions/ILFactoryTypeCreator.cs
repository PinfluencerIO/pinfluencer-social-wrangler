using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions
{
    /// <summary>
    ///     IL type creator of the factory implementation type
    /// </summary>
    /// <remarks>
    ///     Example implementation type should look like this:
    ///     public class DynamicFactoryForIMyFactory : IMyFactory
    ///     {
    ///     // these fields are emitted only if the services
    ///     // in their constructors require these values
    ///     private readonly ISomeService someService;
    ///     public DynamicFactoryForIMyFactory(ISomeService someService)
    ///     {
    ///     this.someService = someService;
    ///     }
    ///     public IFoo Factory()
    ///     {
    ///     return new Foo();
    ///     }
    ///     // parameters should be automatically assigned to the matching ctor
    ///     public IFoo Factory(string param1)
    ///     {
    ///     return new Foo(param1);
    ///     }
    ///     // parameters should be automatically assigned to the matching ctor
    ///     // also with the resolved service
    ///     public IBar Factory(int param1)
    ///     {
    ///     return new Bar(param1, this.someService);
    ///     }
    ///     }
    /// </remarks>
    internal static class IlFactoryTypeCreator
    {
        public static Type CreateType( FactoryClassBuilder builder, Type factory )
        {
            _ = builder ?? throw new ArgumentNullException( nameof( builder ) );

            // assembly stuff
            var appDomain = Thread.GetDomain( );
            var asmName = new AssemblyName { Name = "ToFactoryDynamicAssembly" };
            var asmBuilder = AssemblyBuilder.DefineDynamicAssembly( asmName, AssemblyBuilderAccess.Run );

            var moduleBuilder = asmBuilder.DefineDynamicModule( "ToFactoryModule" );
            var objType = Type.GetType( "System.Object" );
            var objCtor = objType?.GetConstructor( new Type[ 0 ] );

            // type construction
            var facBuilder = moduleBuilder.DefineType( $"DynamicFactoryFor{factory.Name}",
                TypeAttributes.Public
                | TypeAttributes.AutoClass
                | TypeAttributes.AnsiClass
                | TypeAttributes.BeforeFieldInit );

            facBuilder.AddInterfaceImplementation( factory );

            var fieldBuilders = new Dictionary<string, FieldBuilder>( );
            foreach( var item in builder.PrivateReadonlyFields )
            {
                var fieldBuilder = facBuilder.DefineField( item.Name, item.Type,
                    FieldAttributes.Private | FieldAttributes.InitOnly );
                fieldBuilders.Add( item.Name, fieldBuilder );
            }

            // ctor construction
            var ctorParams = builder.PrivateReadonlyFields.Select( t => t.Type ).ToArray( );
            var facCtorBuilder = facBuilder.DefineConstructor(
                MethodAttributes.Public
                | MethodAttributes.HideBySig
                | MethodAttributes.SpecialName
                | MethodAttributes.RTSpecialName, CallingConventions.Standard, ctorParams );

            var ctorIl = facCtorBuilder.GetILGenerator( );
            ctorIl.Emit( OpCodes.Ldarg_0 );
            ctorIl.Emit( OpCodes.Call, objCtor ?? throw new InvalidOperationException( ) );
            //ctorIL.Emit(OpCodes.Nop);

            // generate IL code for assigning the fields with types (parsed from the resolved type constructors) 
            // resolved by the IoC container

            for( var i = 0; i < builder.PrivateReadonlyFields.Count; i++ )
            {
                ctorIl.Emit( OpCodes.Ldarg_0 );

                if( i == 0 )
                    ctorIl.Emit( OpCodes.Ldarg_1 );
                else if( i == 1 )
                    ctorIl.Emit( OpCodes.Ldarg_2 );
                else if( i == 2 )
                    ctorIl.Emit( OpCodes.Ldarg_3 );
                else
                    ctorIl.Emit( OpCodes.Ldarg_S, builder.PrivateReadonlyFields[ i ].Name );

                ctorIl.Emit( OpCodes.Stfld, fieldBuilders[ builder.PrivateReadonlyFields[ i ].Name ] );
            }

            ctorIl.Emit( OpCodes.Ret );


            // build the factory methods
            foreach( var facMethod in builder.FactoryMethods )
            {
                var types = facMethod.Parameters
                    .Where( p => !p.IsFromField && !p.IsFactoryReinjection )
                    .Select( p => p.Type )
                    .ToArray( );

                var methodBuilder = facBuilder.DefineMethod( "Factory",
                    MethodAttributes.Public
                    | MethodAttributes.HideBySig
                    | MethodAttributes.NewSlot
                    | MethodAttributes.Virtual
                    | MethodAttributes.Final,
                    facMethod.FactoryInterfaceMethodInfo.ReturnType,
                    types );

                // assign the method parameters
                // into the constructed type ctor
                var methodIl = methodBuilder.GetILGenerator( );
                methodIl.Emit( OpCodes.Nop );
                //methodIL.Emit(OpCodes.Nop);
                for( var i = 0; i < facMethod.Parameters.Count; i++ )
                {
                    // different op codes if the parameter is derived from field
                    if( facMethod.Parameters[ i ].IsFromField )
                    {
                        methodIl.Emit( OpCodes.Ldarg_0 );
                        methodIl.Emit( OpCodes.Ldfld, fieldBuilders[ facMethod.Parameters[ i ].MatchingField ] );
                        continue;
                    }

                    if( facMethod.Parameters[ i ].IsFactoryReinjection ) { methodIl.Emit( OpCodes.Ldarg_0 ); }
                    else
                    {
                        if( i == 0 )
                            methodIl.Emit( OpCodes.Ldarg_1 );
                        else if( i == 1 )
                            methodIl.Emit( OpCodes.Ldarg_2 );
                        else if( i == 2 )
                            methodIl.Emit( OpCodes.Ldarg_3 );
                        else
                            methodIl.Emit( OpCodes.Ldarg_S, facMethod.Parameters[ i ].MatchingField );
                    }
                }

                methodIl.Emit( OpCodes.Newobj, facMethod.MatchingCtor );
                methodIl.Emit( OpCodes.Ret );
            }

            return facBuilder.CreateTypeInfo( );
        }
    }
}
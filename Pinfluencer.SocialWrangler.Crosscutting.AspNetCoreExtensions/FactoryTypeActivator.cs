using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions
{
    /// <summary>
    ///     Activates the dynamically created factory type
    /// </summary>
    internal static class FactoryTypeActivator
    {
        internal static object Activate( IServiceProvider sp, Type facType )
        {
            var ctor = facType.GetConstructors( ).FirstOrDefault( );
            var ctorParams = ctor?.GetParameters( );
            
            return ctor?
                .Invoke( ( from ctorParam in ctorParams
                        select sp
                            .GetRequiredService( ctorParam.ParameterType ) )
                    .ToArray( ) );
        }
    }
}
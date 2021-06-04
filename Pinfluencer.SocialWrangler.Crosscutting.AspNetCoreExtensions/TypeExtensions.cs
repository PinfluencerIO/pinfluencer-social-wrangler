using System;

namespace Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions
{
    internal static class TypeExtensions
    {
        /// <summary>
        ///     https://stackoverflow.com/questions/863881/how-do-i-tell-if-a-type-is-a-simple-type-i-e-holds-a-single-value
        /// </summary>
        public static bool IsSimple( this Type type )
        {
            if( type.IsGenericType && type.GetGenericTypeDefinition( ) == typeof( Nullable<> ) )
                // nullable type, check if the nested type is simple.
                return IsSimple( type.GetGenericArguments( )[ 0 ] );
            return type.IsPrimitive
                   || type.IsEnum
                   || type == typeof( string )
                   || type == typeof( decimal );
        }
    }
}
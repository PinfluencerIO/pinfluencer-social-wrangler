using System;
using System.Linq;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public static class EnumExtensions
    {
        public static string Stringify<T>( this T enumVal ) where T : Enum { return enumVal.ToString( ).ToLower( ); }

        public static T Enumify<T>( this string enumString ) where T : Enum
        {
            return( Enum.GetValues( typeof( T ) ) as T [ ] ).First( x => x.ToString( ) == enumString );
        }

        public static T [ ] GetValues<T>( ) where T : Enum { return Enum.GetValues( typeof( T ) ) as T [ ]; }
    }
}
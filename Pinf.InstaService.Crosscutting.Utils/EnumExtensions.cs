using System;
using System.Linq;

namespace Pinf.InstaService.Crosscutting.Utils
{
    public static class EnumExtensions
    {
        public static string Stringify<T>( this T enumVal ) where T : System.Enum => enumVal.ToString( ).ToLower( );

        public static T Enumify<T>( this string enumString ) where T : System.Enum => ( System.Enum.GetValues( typeof( T ) ) as T [ ] ).First( x => x.Stringify( ) == enumString );
    }
}
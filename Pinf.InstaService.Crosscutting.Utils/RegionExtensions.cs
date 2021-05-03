using System.Globalization;

namespace Pinf.InstaService.Crosscutting.Utils
{
    public static class RegionExtensions
    {
        public static RegionInfo GetRegion( CountryEnum country ) => new RegionInfo( country.ToString( ) );
        
        public static string Stringify( this CountryEnum country ) => country.ToString( );
    }
}
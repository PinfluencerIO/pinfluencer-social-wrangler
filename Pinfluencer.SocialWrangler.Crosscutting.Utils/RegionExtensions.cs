﻿using System.Globalization;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public static class RegionExtensions
    {
        public static RegionInfo GetRegion( CountryEnum country ) => new RegionInfo( country.ToString( ) );
        
        public static string Stringify( this CountryEnum country ) => country.ToString( );
    }
}
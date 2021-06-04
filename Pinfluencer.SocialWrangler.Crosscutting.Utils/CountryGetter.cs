using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Pinfluencer.SocialWrangler.Core.Attributes;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class CountryGetter : ICountryGetter
    {
        public ReadOnlyDictionary<CountryEnum, string> Countries { get; }

        public CountryGetter( )
        {
            var countries = new Dictionary<CountryEnum, string>( );
            foreach( var valueTuple in( Enum.GetValues( typeof( CountryEnum ) ) as CountryEnum [ ] ??
                                        throw new InvalidOperationException( ) )
                .Select( x => ( x, typeof( CountryEnum ).GetMember( x.ToString( ) ).FirstOrDefault( ) ) )
                .Select( x => ( x, x.Item2.GetCustomAttribute<CountryAttribute>( )?.Name ) ) )
            {
                countries.Add( valueTuple.x.x, valueTuple.Name );
            }
            Countries = new ReadOnlyDictionary<CountryEnum, string>( countries );
        }
    }
}
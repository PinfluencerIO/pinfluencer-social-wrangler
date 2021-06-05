using System.Collections.ObjectModel;
using Pinfluencer.SocialWrangler.Core.Attributes;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract
{
    [ Service( Scope = ServiceLifetimeEnum.Singleton ) ]
    public interface ICountryGetter
    {
        public ReadOnlyDictionary<CountryEnum, string> Countries { get; }
    }
}
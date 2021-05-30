using System.Linq;
using Newtonsoft.Json.Serialization;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class PinfluencerJsonResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName( string propertyName ) => string.Concat(
                base.ResolvePropertyName( propertyName )
                    .Select( ( x, i ) => i > 0 && char.IsUpper( x ) ? "_" + x : x.ToString( ) ) )
            .ToLower( );
    }
}
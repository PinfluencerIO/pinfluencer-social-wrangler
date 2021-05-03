using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pinf.InstaService.API.InstaFetcher.Configuration
{
    public class DefaultJsonResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName( string propertyName ) => string.Concat(
            base.ResolvePropertyName( propertyName )
                .Select( ( x, i ) => i > 0 && char.IsUpper( x ) ? "_" + x : x.ToString( ) ) )
                .ToLower( );

        protected override JsonProperty CreateProperty( MemberInfo member, MemberSerialization memberSerialization )
        {
            return base.CreateProperty( member, memberSerialization );
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Pinf.InstaService.API.InstaFetcher.ResponseDtos
{
    public class CollectionDto<T>
    {
        [ JsonPropertyName( "collection" ) ]
        public IEnumerable<T> Collection { get; set; }
        
        [ JsonPropertyName( "has_multiple" ) ]
        public bool Multiple => Collection.Count() > 1;

        [ JsonPropertyName( "is_empty" ) ]
        public bool Empty => !Collection.Any();
    }
}
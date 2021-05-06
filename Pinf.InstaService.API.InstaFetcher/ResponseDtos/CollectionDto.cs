using System.Collections.Generic;
using System.Linq;

namespace Pinf.InstaService.API.InstaFetcher.ResponseDtos
{
    public class CollectionDto<T>
    {
        public IEnumerable<T> Collection { get; set; }
        
        public bool HasMultiple => Collection.Count() > 1;
        
        public bool IsEmpty => !Collection.Any();
    }
}
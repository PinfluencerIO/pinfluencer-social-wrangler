using System.Collections.Generic;
using System.Linq;

namespace Pinfluencer.SocialWrangler.API.Core.Dtos.Response
{
    public class CollectionDto<T>
    {
        public IEnumerable<T> Collection { get; set; }

        public bool HasMultiple => Collection.Count( ) > 1;

        public bool IsEmpty => !Collection.Any( );
    }
}
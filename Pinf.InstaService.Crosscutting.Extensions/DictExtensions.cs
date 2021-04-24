using System.Collections.Generic;

namespace Pinf.InstaService.Crosscutting.Extensions
{
    public static class DictExtensions<T1, T2>
    {
        public static Dictionary<T1, T2> Create( T1 key, T2 value )
        {
            var dict = new Dictionary<T1, T2> { { key, value } };
            return dict;
        }
    }
}
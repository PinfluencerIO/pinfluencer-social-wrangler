using System;
using System.Collections.Generic;
using System.Linq;

namespace Pinf.InstaService.BLL.Models.Validation
{
    public class ValidateInstaAudienceAgeRange : IValidatable
    {
        public Tuple<int, int> AgeRange { get; set; }

        public IEnumerable<Tuple<int, int>> AgeRanges { get; } = new [ ]
        {
            new Tuple<int, int>( 13, 17 ),
            new Tuple<int, int>( 18, 24 ),
            new Tuple<int, int>( 25, 34 ),
            new Tuple<int, int>( 35, 44 ),
            new Tuple<int, int>( 45, 54 ),
            new Tuple<int, int>( 55, 64 )
        };

        public bool Validate( )
        {
            return AgeRanges.Any( fixedAgeRange =>
                fixedAgeRange.Item1 == AgeRange.Item1 && fixedAgeRange.Item2 == AgeRange.Item2 );
        }
    }
}
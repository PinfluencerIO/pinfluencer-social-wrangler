using System;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Core.Models.Insights
{
    public class GenderAgeProperty
    {
        public GenderEnum Gender { get; }

        public Tuple<int, int> AgeRange { get; set; }
    }
}
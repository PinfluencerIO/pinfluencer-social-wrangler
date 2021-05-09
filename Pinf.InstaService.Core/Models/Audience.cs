using System;
using System.Collections.Generic;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Core.Models
{
    public class Audience
    {
        public string Id { get; set; }
        
        public IEnumerable<AudiencePercentage<GenderEnum>> AudienceGender { get; set; }
        
        public IEnumerable<AudiencePercentage<LocationProperty>> AudienceLocation { get; set; }
        
        public IEnumerable<AudiencePercentage<AgeProperty>> AudienceAge { get; set; }
    }
}
using System.Collections.Generic;

namespace Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble
{
    public class Audience
    {
        public IEnumerable<string> AudienceGender { get; set; }
        
        public IEnumerable<string> AudienceLocation { get; set; }
        
        public IEnumerable<string> AudienceAge { get; set; }
    }
}
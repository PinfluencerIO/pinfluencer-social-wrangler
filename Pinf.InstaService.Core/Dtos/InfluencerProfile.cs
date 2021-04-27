using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Core.Dtos
{
    public class InfluencerProfile
    {
        public string ProfileId { get; set; }
        public string Auth0Id { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Core.Models.User
{
    public class Influencer
    {
        public string InstagramHandle { get; set; }
        public User User { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public GenderEnum Gender { get; set; }
        public int Age { get; set; }
    }
}
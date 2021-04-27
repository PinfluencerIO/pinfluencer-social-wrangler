using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Core.Models.User
{
    public class Influencer
    {
        public string InstagramHandle { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public User User { get; set; }
        public GenderEnum GenderEnum { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
    }
}
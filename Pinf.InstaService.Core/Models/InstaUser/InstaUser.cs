using System.Text.Json.Serialization;

namespace Pinf.InstaService.Core.Models.InstaUser
{
    public class InstaUser
    {
        public string Handle { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public int Followers { get; set; }
    }
}
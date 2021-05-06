using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions
{
    public class FakeUserProps
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
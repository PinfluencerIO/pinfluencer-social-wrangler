using Newtonsoft.Json;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;

namespace Pinf.InstaService.Local.Sandbox
{
    internal class Program
    {
        private static void Main( string [ ] args )
        {
            var json = JsonConvert.SerializeObject( new Influencer
            {
                Age = 24,
                Bio = "this is a bio",
                Gender = GenderEnum.Male,
                Instagram = "example",
                Location = "Dorchester, Dorset",
                Profile = "123453"
            } );
        }
    }

    public class TestDto
    {
        public string Name { get; set; }
        public TestNestedDto Type { get; set; }
    }

    public class TestNestedDto
    {
        public int Prop { get; set; }
    }
}
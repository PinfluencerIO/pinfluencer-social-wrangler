using Newtonsoft.Json;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Pinf.InstaService.DAL.UserManagement.Dtos.Facebook;

namespace Pinf.InstaService.Local.Sandbox
{
    internal class Program
    {
        private static void Main( string [ ] args )
        {
            var json = JsonConvert.DeserializeObject<FacebookUser>
            (@"{ 
                'birthday': '11/26/1999',
                'location': {
                    'id': '109435875749334',
                    'name': 'Dorchester, Dorset'
                },
                'gender': 'male',
                'id': '706884236570098'
            }");
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
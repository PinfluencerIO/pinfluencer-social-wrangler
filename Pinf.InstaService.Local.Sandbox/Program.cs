using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Pinf.InstaService.Local.Sandbox
{
    internal class Program
    {
        private static void Main( string [ ] args )
        {
            var MockConfiguration = new ConfigurationBuilder( )
                .AddJsonStream( new MemoryStream( Encoding.UTF8.GetBytes( JsonConvert.SerializeObject( new TestDto
                {
                    Name = "",
                    Type = new TestNestedDto
                    {
                        Prop = 5
                    }
                } ) ) ) )
                .Build( );
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
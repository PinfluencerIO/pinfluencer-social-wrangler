using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions
{
    public static class FakeConfiguration
    {
        public static IConfiguration GetFake<T>( T optionsDto )
        {
            var builder = new ConfigurationBuilder( );
            var json = JsonConvert.SerializeObject( optionsDto );
            var bytes = Encoding.UTF8.GetBytes( json );
            var memoryStream = new MemoryStream( bytes );
            builder.AddJsonStream( memoryStream );
            return builder.Build( );
        }
    }
}
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Pinf.InstaService.Crosscutting.NUnit.Extensions
{
    public static class FakeConfiguration
    {
        public static IConfiguration GetFake<T>( T optionsDto ) => new ConfigurationBuilder( )
            .AddJsonStream( new MemoryStream( Encoding.UTF8.GetBytes( JsonConvert.SerializeObject( optionsDto ) ) ) )
            .Build( );
    }
}
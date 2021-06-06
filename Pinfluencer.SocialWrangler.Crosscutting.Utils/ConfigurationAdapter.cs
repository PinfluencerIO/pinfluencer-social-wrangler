using Microsoft.Extensions.Configuration;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class ConfigurationAdapter : IConfigurationAdapter
    {
        private readonly IConfiguration _configuration;

        public ConfigurationAdapter( IConfiguration configuration ) { _configuration = configuration; }

        public T Get<T>( ) => _configuration.Get<T>( );
    }
}
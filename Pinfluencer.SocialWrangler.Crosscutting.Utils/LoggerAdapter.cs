using Microsoft.Extensions.Logging;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class LoggerAdapter<T> : ILoggerAdapter<T> where T : class
    {
        private readonly ILogger _logger;
        
        public LoggerAdapter( ILogger<T> logger ) { _logger = logger; }

        public void LogInfo( string message ) => _logger.LogInformation( message );

        public void LogError( string message ) => _logger.LogError( message );
    }
}
using Microsoft.Extensions.Logging;

namespace Pinf.InstaService.Crosscutting.Utils
{
    public class LoggerAdapter : ILoggerAdapter
    {
        private readonly ILogger _logger;
        
        public LoggerAdapter( ILogger logger ) { _logger = logger; }

        public void LogInfo( string message ) => _logger.LogInformation( message );

        public void LogError( string message ) => _logger.LogError( message );
    }
}
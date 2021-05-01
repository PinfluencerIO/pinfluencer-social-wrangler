namespace Pinf.InstaService.Crosscutting.Utils
{
    public interface ILoggerAdapter
    {
        void LogInfo( string message );

        void LogError( string message );
    }
}
namespace Pinf.InstaService.Crosscutting.Utils
{
    public interface ILoggerAdapter<T> where T : class
    {
        void LogInfo( string message );

        void LogError( string message );
    }
}
namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting
{
    public interface ILoggerAdapter<T> where T : class
    {
        void LogInfo( string message );

        void LogError( string message );
    }
}
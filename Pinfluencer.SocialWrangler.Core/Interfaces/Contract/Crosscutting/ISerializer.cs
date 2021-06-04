namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting
{
    public interface ISerializer
    {
        string Serialize( object content );

        T Deserialize<T>( string content );
    }
}
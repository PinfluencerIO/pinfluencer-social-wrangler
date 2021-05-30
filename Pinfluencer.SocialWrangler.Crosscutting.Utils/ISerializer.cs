namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public interface ISerializer
    {
        string Serialize( object content );

        T Deserialize<T>( string content );
    }
}
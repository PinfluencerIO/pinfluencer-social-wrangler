namespace Pinf.InstaService.Crosscutting.Utils
{
    public interface ISerializer
    {
        string Serialzie( object content );

        T Deserialize<T>( string content );
    }
}
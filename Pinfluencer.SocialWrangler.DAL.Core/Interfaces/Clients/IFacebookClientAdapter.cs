namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients
{
    public interface IFacebookClientAdapter
    {
        object Get( string path, object parameters );
    }
}
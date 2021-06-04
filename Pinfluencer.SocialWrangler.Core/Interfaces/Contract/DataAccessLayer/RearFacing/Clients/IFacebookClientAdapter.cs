namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients
{
    public interface IFacebookClientAdapter
    {
        object Get( string path, object parameters );
    }
}
namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients
{
    public interface IFacebookClientAdapter
    {
        object Get( string path, object parameters );
    }
}
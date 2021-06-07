using Pinfluencer.SocialWrangler.Core;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing
{
    public interface IFacebookTokenRepository
    {
        ObjectResult<string> Get( string authId );
    }
}
using Pinfluencer.SocialWrangler.Core;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing
{
    public interface ITokenRepository
    {
        ObjectResult<string> Get( string authId );
    }
}
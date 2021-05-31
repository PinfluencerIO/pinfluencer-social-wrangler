using Pinfluencer.SocialWrangler.Core;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces
{
    public interface ITokenRepository
    {
        OperationResult<string> Get( string authId );
    }
}
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Social
{
    public interface ISocialInfoUserRepository
    {
        OperationResult<SocialInfoUser> Get( );
    }
}
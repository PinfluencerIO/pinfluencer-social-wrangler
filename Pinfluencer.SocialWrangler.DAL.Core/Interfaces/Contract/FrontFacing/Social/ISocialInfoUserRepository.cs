using Aidan.Common.Core;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface ISocialInfoUserRepository
    {
        ObjectResult<SocialInfoUser> Get( );
    }
}
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Repositories
{
    public interface IInfluencerRepository
    {
        OperationResultEnum Create( Influencer influencer );
    }
}
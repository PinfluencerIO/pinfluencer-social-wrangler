using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer
{
    public interface IInfluencerRepository
    {
        OperationResultEnum Create( Influencer influencer );
    }
}
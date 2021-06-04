using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.BuisnessLayer
{
    public interface IInfluencerFacade
    {
        OperationResultEnum OnboardInfluencer( string id );
    }
}
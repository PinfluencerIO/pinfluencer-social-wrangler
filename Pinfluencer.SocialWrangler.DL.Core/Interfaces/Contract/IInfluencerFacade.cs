using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface IInfluencerFacade
    {
        OperationResultEnum Onboard( string id );
    }
}
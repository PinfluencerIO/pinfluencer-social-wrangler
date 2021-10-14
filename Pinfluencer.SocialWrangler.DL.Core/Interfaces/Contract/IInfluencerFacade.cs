using Aidan.Common.Core.Enum;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface IInfluencerFacade
    {
        OperationResultEnum Onboard( string id );
    }
}
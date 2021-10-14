using Aidan.Common.Core;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface IGetInfluencerFromSocialCommand
    {
        ObjectResult<Influencer> Run( );
    }
}
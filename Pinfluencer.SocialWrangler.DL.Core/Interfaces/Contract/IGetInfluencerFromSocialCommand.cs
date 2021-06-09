using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface IGetInfluencerFromSocialCommand
    {
        ObjectResult<Influencer> Run( );
    }
}
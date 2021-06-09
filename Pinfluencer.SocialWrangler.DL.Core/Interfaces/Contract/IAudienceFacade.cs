using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface IAudienceFacade
    {
        ObjectResult<Audience> GetFromSocial( );
    }
}
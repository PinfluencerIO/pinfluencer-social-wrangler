using Aidan.Common.Core;
using Pinfluencer.SocialWrangler.Core.Models;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface IAudienceFacade
    {
        ObjectResult<Audience> GetFromSocial( );
    }
}
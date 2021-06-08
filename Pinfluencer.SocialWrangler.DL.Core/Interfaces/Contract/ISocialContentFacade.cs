using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface ISocialContentFacade
    {
        ObjectResult<int> GetImpressions( string id );
        ObjectResult<IEnumerable<ContentReach>> GetReach( string id );
    }
}
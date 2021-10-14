using System.Collections.Generic;
using Aidan.Common.Core;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface ISocialInsightUserFacade
    {
        ObjectResult<IEnumerable<SocialInsightsUser>> GetUsers( );
        
        ObjectResult<SocialInsightsUser> GetFirstUser( );
    }
}
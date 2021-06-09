using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface IInsightsSocialUserRepository
    {
        ObjectResult<SocialInsightsUser> Get( string id );

        ObjectResult<IEnumerable<SocialInsightsUser>> GetAll( );
    }
}
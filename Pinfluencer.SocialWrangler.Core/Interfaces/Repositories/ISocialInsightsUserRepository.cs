using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Repositories
{
    public interface IInsightsSocialUserRepository
    {
        OperationResult<SocialInsightsUser> Get( string id );

        OperationResult<IEnumerable<SocialInsightsUser>> GetAll( );
    }
}
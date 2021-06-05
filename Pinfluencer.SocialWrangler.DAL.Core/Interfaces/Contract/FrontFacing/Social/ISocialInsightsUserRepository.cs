using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface IInsightsSocialUserRepository
    {
        OperationResult<SocialInsightsUser> Get( string id );

        OperationResult<IEnumerable<SocialInsightsUser>> GetAll( );
    }
}
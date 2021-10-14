using System.Collections.Generic;
using Aidan.Common.Core;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface IInsightsSocialUserRepository
    {
        ObjectResult<SocialInsightsUser> Get( string id );

        ObjectResult<IEnumerable<SocialInsightsUser>> GetAll( );
    }
}
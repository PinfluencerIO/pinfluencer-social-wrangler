using System.Collections.Generic;
using Aidan.Common.Core;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface ISocialContentRepository
    {
        ObjectResult<IEnumerable<Content>> GetAll( string user );
    }
}
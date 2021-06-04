using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Social
{
    //TODO: add time start and time end inputs
    public interface ISocialImpressionsRepository
    {
        OperationResult<IEnumerable<ContentImpressions>> Get( string instaId );
    }
}
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Repositories
{
    //TODO: add time start and time end inputs
    public interface ISocialImpressionsRepository
    {
        OperationResult<IEnumerable<ContentImpressions>> GetImpressions( string instaId );
    }
}
using System.Collections.Generic;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    //TODO: add time start and time end inputs
    public interface ISocialImpressionsRepository
    {
        OperationResult<IEnumerable<ContentImpressions>> GetImpressions( string instaId );
    }
}
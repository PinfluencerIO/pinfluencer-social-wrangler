using System.Collections.Generic;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    //TODO: add time start and time end inputs
    public interface IInstaImpressionsRepository
    {
        OperationResult<IEnumerable<ProfileViewsInsight>> GetImpressions( string instaId );
    }
}
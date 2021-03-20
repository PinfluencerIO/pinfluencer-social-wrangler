using System.Collections.Generic;
using Pinf.InstaService.BLL.Models.Insights;

namespace Pinf.InstaService.Bootstrapping.Services.Repositories
{
    //TODO: add time start and time end inputs
    public interface IInstaImpressionsRepository
    {
        OperationResult<IEnumerable<InstaImpression>> GetImpressions(string instaId);
    }
}
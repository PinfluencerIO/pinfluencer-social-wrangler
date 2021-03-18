using System.Collections.Generic;
using BLL.Models.Insights;

namespace Bootstrapping.Services.Repositories
{
    //TODO: add time start and time end inputs
    public interface IInstaImpressionsRepository
    {
        OperationResult<IEnumerable<InstaImpression>> GetImpressions(string instaId);
    }
}
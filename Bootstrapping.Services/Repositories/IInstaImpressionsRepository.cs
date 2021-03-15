using System.Collections.Generic;
using BLL.Models;
using BLL.Models.Insights;

namespace Bootstrapping.Services.Repositories
{
    public interface IInstaImpressionsRepository
    {
        OperationResult<IEnumerable<InstaImpression>> GetImpressions(string instaId);
    }
}
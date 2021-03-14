using System.Collections.Generic;
using BLL.Models;

namespace Bootstrapping.Services.Repositories
{
    public interface IInstaImpressionsRepository
    {
        OperationResult<IEnumerable<InstaImpression>> GetImpressions(string instaId);
    }
}
using System.Collections.Generic;
using Pinf.InstaService.BLL.Models.Insights;

namespace Pinf.InstaService.BLL.Core.Repositories
{
    public interface IInstaAudienceInsightsRepository
    {
        OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> GetCountry(string instaId);

        OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> GetGenderAge(string instaId);
    }
}
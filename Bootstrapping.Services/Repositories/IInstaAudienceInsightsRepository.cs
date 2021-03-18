using System.Collections.Generic;
using BLL.Models.Insights;

namespace Bootstrapping.Services.Repositories
{
    public interface IInstaAudienceInsightsRepository
    {
        OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> GetCountry(string instaId);

        OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> GetGenderAge(string instaId);
    }
}
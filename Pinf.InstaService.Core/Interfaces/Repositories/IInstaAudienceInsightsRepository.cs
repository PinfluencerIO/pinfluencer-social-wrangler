using System.Collections.Generic;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IInstaAudienceInsightsRepository
    {
        OperationResult<IEnumerable<FollowersInsight<CountryProperty>>> GetCountry( string instaId );

        OperationResult<IEnumerable<FollowersInsight<GenderAgeProperty>>> GetGenderAge( string instaId );
    }
}
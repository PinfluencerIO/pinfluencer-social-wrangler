using System.Collections.Generic;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IInstaAudienceInsightsRepository
    {
        OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> GetCountry( string instaId );

        OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> GetGenderAge( string instaId );
    }
}
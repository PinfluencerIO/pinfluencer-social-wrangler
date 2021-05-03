using System.Collections.Generic;
using System.Globalization;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IInstaAudienceInsightsRepository
    {
        OperationResult<IEnumerable<FollowersInsight<RegionInfo>>> GetCountry( string instaId );

        OperationResult<IEnumerable<FollowersInsight<GenderAgeProperty>>> GetGenderAge( string instaId );
    }
}
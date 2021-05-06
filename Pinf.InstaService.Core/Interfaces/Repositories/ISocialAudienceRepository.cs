using System.Collections.Generic;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface ISocialAudienceRepository
    {
        OperationResult<IEnumerable<AudienceCount<LocationProperty>>> GetCountry( string instaId );

        OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>> GetGenderAge( string instaId );
    }
}
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Repositories
{
    public interface ISocialAudienceRepository
    {
        OperationResult<IEnumerable<AudienceCount<LocationProperty>>> GetCountry( string instaId );

        OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>> GetGenderAge( string instaId );
    }
}
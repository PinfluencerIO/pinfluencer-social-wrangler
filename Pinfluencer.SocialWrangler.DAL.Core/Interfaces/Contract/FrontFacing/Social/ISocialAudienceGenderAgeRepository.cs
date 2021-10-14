using System.Collections.Generic;
using Aidan.Common.Core;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface ISocialAudienceGenderAgeRepository
    {
        ObjectResult<IEnumerable<AudienceCount<GenderAgeProperty>>> Get( string instaId );
    }
}
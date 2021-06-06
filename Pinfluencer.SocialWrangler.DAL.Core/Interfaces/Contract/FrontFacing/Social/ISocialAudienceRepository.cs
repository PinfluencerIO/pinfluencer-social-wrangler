using System;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    [ Obsolete ]
    public interface ISocialAudienceRepository
    {
        ObjectResult<IEnumerable<AudienceCount<LocationProperty>>> GetCountry( string instaId );

        ObjectResult<IEnumerable<AudienceCount<GenderAgeProperty>>> GetGenderAge( string instaId );
    }
}
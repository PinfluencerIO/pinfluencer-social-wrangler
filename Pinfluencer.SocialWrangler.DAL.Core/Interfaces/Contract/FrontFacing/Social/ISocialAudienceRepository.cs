﻿using System;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    [ Obsolete ]
    public interface ISocialAudienceRepository
    {
        OperationResult<IEnumerable<AudienceCount<LocationProperty>>> GetCountry( string instaId );

        OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>> GetGenderAge( string instaId );
    }
}
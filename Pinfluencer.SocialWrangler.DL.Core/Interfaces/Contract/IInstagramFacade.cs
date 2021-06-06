﻿using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface IInstagramFacade
    {
        ObjectResult<IEnumerable<ContentImpressions>> GetMonthlyProfileViews( string id );
        ObjectResult<IEnumerable<SocialInsightsUser>> GetUsers( );
        ObjectResult<IEnumerable<AudiencePercentage<LocationProperty>>> GetAudienceCountryInsights( string id );
        ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAudienceGenderInsights( string id );
        ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAudienceAgeInsights( string id );
    }
}
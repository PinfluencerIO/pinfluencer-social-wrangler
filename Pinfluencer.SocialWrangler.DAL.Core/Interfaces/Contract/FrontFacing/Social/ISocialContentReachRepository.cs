using System;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface ISocialContentReachRepository
    {
        ObjectResult<IEnumerable<ContentReach>> Get( string instaId, PeriodEnum resolution,
            ( DateTime start, DateTime end ) capturePeriod );
    }
}
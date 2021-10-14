using System;
using System.Collections.Generic;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface ISocialContentImpressionsRepository
    {
        ObjectResult<IEnumerable<ContentImpressions>> Get( string instaId, PeriodEnum resolution,
            ( DateTime start, DateTime end ) capturePeriod );
    }
}
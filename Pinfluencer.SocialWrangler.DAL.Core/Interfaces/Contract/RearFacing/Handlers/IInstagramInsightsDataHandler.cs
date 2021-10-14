using System;
using System.Collections.Generic;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers
{
    public interface IInstagramInsightsDataHandler<T> where T : SocialInsightsBase, new( )
    {
        IEnumerable<T> MapMany( DataArray<Metric<int>> dtoCollection );

        ObjectResult<IEnumerable<T>> Read( string instaId, PeriodEnum resolution,
            ( DateTime start, DateTime end ) capturePeriod, string metric );
    }
}
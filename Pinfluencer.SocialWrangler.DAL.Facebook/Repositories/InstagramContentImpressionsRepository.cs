using System;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramContentImpressionsRepository : ISocialContentImpressionsRepository
    {
        private readonly IInstagramInsightsDataHandler<ContentImpressions> _instagramInsightsDataHandler;
        
        public InstagramContentImpressionsRepository( IInstagramInsightsDataHandler<ContentImpressions> instagramInsightsDataHandler )
        {
            _instagramInsightsDataHandler = instagramInsightsDataHandler;
        }

        public ObjectResult<IEnumerable<ContentImpressions>> Get( string instaId, PeriodEnum resolution,
            ( DateTime start, DateTime end ) capturePeriod )
        {
            return _instagramInsightsDataHandler.Read( instaId,
                resolution,
                ( capturePeriod.start, capturePeriod.end ),
                "impressions" );
        }
    }
}
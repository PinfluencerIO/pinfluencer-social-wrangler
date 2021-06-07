using System;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramContentReachRepository
    {
        private readonly IInstagramInsightsDataHandler<ContentReach> _instagramInsightsDataHandler;
        
        public InstagramContentReachRepository( IInstagramInsightsDataHandler<ContentReach> instagramInsightsDataHandler )
        {
            _instagramInsightsDataHandler = instagramInsightsDataHandler;
        }
        
        public ObjectResult<IEnumerable<ContentReach>> Get( string instaId, PeriodEnum resolution,
            ( DateTime start, DateTime end ) capturePeriod )
        {
            return _instagramInsightsDataHandler.Read( instaId, resolution, capturePeriod, "reach" );
        }
    }
}
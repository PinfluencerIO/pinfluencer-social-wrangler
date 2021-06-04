using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramContentImpressionsRepository : 
        IDataCollectionMappable<IEnumerable<ContentImpressions>,
            DataArray<Metric<int>>>
    {
        private readonly IFacebookDataHandler<InstagramContentImpressionsRepository> _facebookDataHandler;

        public InstagramContentImpressionsRepository( IFacebookDataHandler<InstagramContentImpressionsRepository> facebookDataHandler )
        {
            _facebookDataHandler = facebookDataHandler;
        }
        
        public OperationResult<IEnumerable<ContentImpressions>> Get( string instaId, PeriodEnum resolution, ( DateTime start, DateTime end ) capturePeriod )
        {
            var startMinsEpoch = capturePeriod.start - new DateTime( 1970, 1, 1 );
            var endMinsEpoch = capturePeriod.end - new DateTime( 1970, 1, 1 );
            var startUnix = startMinsEpoch.TotalSeconds;
            var endUnix = endMinsEpoch.TotalSeconds;

            string periodString;
            switch( resolution )
            {
                case PeriodEnum.Day:
                    periodString = "day";
                    break;
                case PeriodEnum.Day28:
                    periodString = "days_28";
                    break;
                case PeriodEnum.Week:
                    periodString = "week";
                    break;
                default:
                    return new OperationResult<IEnumerable<ContentImpressions>>(
                        Enumerable.Empty<ContentImpressions>( ),
                        OperationResultEnum.Failed );
            }
            
            return _facebookDataHandler
                .Read<IEnumerable<ContentImpressions>, DataArray<Metric<int>>>( $"{instaId}/insights",
                    MapMany,
                    Enumerable.Empty<ContentImpressions>( ),
                    new RequestInsightParams
                    {
                        metric = "impressions",
                        period = periodString,
                        since = ( int )startUnix,
                        until = ( int )endUnix
                    } );
        }
        
        public IEnumerable<ContentImpressions> MapMany( DataArray<Metric<int>> dtoCollection ) { throw new System.NotImplementedException( ); }
    }
}
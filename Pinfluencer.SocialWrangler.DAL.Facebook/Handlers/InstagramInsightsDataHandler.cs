using System;
using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Handlers
{
    public class InstagramInsightsDataHandler<T> :
        IDataCollectionMappable<IEnumerable<T>,
            DataArray<Metric<int>>>, IInstagramInsightsDataHandler<T> where T : SocialInsightsBase, new()
    {
        private readonly IFacebookDataHandler<T> _facebookDataHandler;
        
        public InstagramInsightsDataHandler( IFacebookDataHandler<T> facebookDataHandler )
        {
            _facebookDataHandler = facebookDataHandler;
        }

        public IEnumerable<T> MapMany( DataArray<Metric<int>> dtoCollection )
        {
            return dtoCollection
                .Data
                .SelectMany( x => x.Insights )
                .Select( x => new T
                {
                    Time = DateTime.Parse( x.Time ),
                    Count = x.Value
                } );
        }

        public ObjectResult<IEnumerable<T>> Read( string instaId, PeriodEnum resolution,
            ( DateTime start, DateTime end ) capturePeriod, string metric )
        {
            var startMinsEpoch = capturePeriod.start - new DateTime( 1970, 1, 1 );
            var endMinsEpoch = capturePeriod.end - new DateTime( 1970, 1, 1 );
            var startUnix = startMinsEpoch.TotalSeconds;
            var endUnix = endMinsEpoch.TotalSeconds;

            string periodString;
            //TODO: move switch into class
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
                    return new ObjectResult<IEnumerable<T>>(
                        Enumerable.Empty<T>( ),
                        OperationResultEnum.Failed );
            }

            return _facebookDataHandler
                .Read<IEnumerable<T>, DataArray<Metric<int>>>( $"{instaId}/insights",
                    MapMany,
                    Enumerable.Empty<T>( ),
                    new RequestInsightParams
                    {
                        metric = metric,
                        period = periodString,
                        since = ( int ) startUnix,
                        until = ( int ) endUnix
                    } );
        }
    }
}
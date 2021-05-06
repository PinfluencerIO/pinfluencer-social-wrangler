using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.CodeContracts;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class InstagramImpressionsRepository : FacebookRepository<InstagramImpressionsRepository>, ISocialImpressionsRepository
    {
        private readonly FacebookContext _facebookContext;
        private readonly ILoggerAdapter<InstagramImpressionsRepository> _logger;

        public InstagramImpressionsRepository( FacebookContext facebookContext, ILoggerAdapter<InstagramImpressionsRepository> logger ) : base( logger )
        {
            _facebookContext = facebookContext;
            _logger = logger;
        }

        //TODO: ADD CUSTOM TIMESPAN
        public OperationResult<IEnumerable<ContentImpressions>> GetImpressions( string instaId )
        {
            var ( impressions, fbResult ) = ValidateFacebookCall( () => _facebookContext.Get( $"{instaId}/insights", new RequestInsightParams
            {
                metric = "impressions",
                period = "day",
                since = 1607650400,
                until = 1610150400
            } ) );
            if( !fbResult )
            {
                _logger.LogError( "instagram profile impressions were not fetched" );
                return new OperationResult<IEnumerable<ContentImpressions>>( Enumerable.Empty<ContentImpressions>( ),
                    OperationResultEnum.Failed );
            }

            var impressionsObj = JsonConvert.DeserializeObject<DataArray<Metric<int>>>( impressions );
            new PostCondition( ).Evaluate( impressionsObj != null );
            var result = new OperationResult<IEnumerable<ContentImpressions>>(
                impressionsObj.Data.First( ).Insights
                    .Select( x => new ContentImpressions( DateTime.Parse( x.Time ), x.Value ) ),
                OperationResultEnum.Success );
            _logger.LogInfo( "instagram profile impressions fetched" );
            return result;
        }
    }
}
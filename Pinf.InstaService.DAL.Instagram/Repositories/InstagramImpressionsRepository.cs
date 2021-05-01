using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
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
    public class InstagramImpressionsRepository : IInstaImpressionsRepository
    {
        private readonly FacebookContext _facebookContext;
        private readonly ILoggerAdapter _logger;

        public InstagramImpressionsRepository( FacebookContext facebookContext, ILoggerAdapter logger )
        {
            _facebookContext = facebookContext;
            _logger = logger;
        }

        //TODO: ADD CUSTOM TIMESPAN
        //TODO: DONT SWALLOW ALL EXCEPTIONS
        public OperationResult<IEnumerable<InstaProfileViewsInsight>> GetImpressions( string instaId )
        {
            try
            {
                var impressions = _facebookContext.Get( $"{instaId}/insights", new RequestInsightParams
                {
                    metric = "impressions",
                    period = "day",
                    since = 1607650400,
                    until = 1610150400
                } );

                var impressionsObj = JsonConvert.DeserializeObject<DataArray<Metric>>( impressions );

                new PostCondition( ).Evaluate( impressionsObj != null );

                var result = new OperationResult<IEnumerable<InstaProfileViewsInsight>>(
                    impressionsObj.Data.First( ).Insights
                        .Select( x => new InstaProfileViewsInsight( DateTime.Parse( x.Time ), x.Value ) ),
                    OperationResultEnum.Success );
                _logger.LogInfo( "instagram profile impressions fetched" );
                return result;
            }
            catch( Exception )
            {
                _logger.LogError( "instagram profile impressions were not fetched" );
                return new OperationResult<IEnumerable<InstaProfileViewsInsight>>( Enumerable.Empty<InstaProfileViewsInsight>( ),
                    OperationResultEnum.Failed );
            }
        }
    }
}
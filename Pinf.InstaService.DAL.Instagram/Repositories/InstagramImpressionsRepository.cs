using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.CodeContracts;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class InstagramImpressionsRepository : IInstaImpressionsRepository
    {
        private readonly FacebookContext _facebookContext;

        public InstagramImpressionsRepository( FacebookContext facebookContext ) { _facebookContext = facebookContext; }

        public OperationResult<IEnumerable<InstaImpression>> GetImpressions( string instaId )
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

                return new OperationResult<IEnumerable<InstaImpression>>(
                    impressionsObj.Data.First( ).Insights
                        .Select( x => new InstaImpression( DateTime.Parse( x.Time ), x.Value ) ),
                    OperationResultEnum.Success );
            }
            catch( Exception )
            {
                return new OperationResult<IEnumerable<InstaImpression>>( Enumerable.Empty<InstaImpression>( ),
                    OperationResultEnum.Failed );
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Models.Insights;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;
using Crosscutting.CodeContracts;
using DAL.Instagram.Dtos;
using Newtonsoft.Json;

namespace DAL.Instagram.Repositories
{
    public class FacebookInstaImpressionsRepository : IInstaImpressionsRepository
    {
        private FacebookInstagramDataContext _facebookInstagramDataContext;

        public FacebookInstaImpressionsRepository(FacebookInstagramDataContext facebookInstagramDataContext)
        {
            _facebookInstagramDataContext = facebookInstagramDataContext;
        }
        
        public OperationResult<IEnumerable<InstaImpression>> GetImpressions(string instaId)
        {
            try
            {
                var impressions = _facebookInstagramDataContext.Get($"{instaId}/insights", new RequestInsightParams
                {
                    metric = "impressions",
                    period = "day",
                    since = 1607650400,
                    until = 1610150400
                });
                
                var impressionsObj = JsonConvert.DeserializeObject<DataArray<Metric>>(impressions);
            
                new PostCondition().Evaluate(impressionsObj!=null);

                return new OperationResult<IEnumerable<InstaImpression>>(
                    impressionsObj.Data.First().Insights.Select(x => new InstaImpression(DateTime.Parse(x.Time), x.Value)),
                    OperationResultEnum.Success);
            }
            catch (Exception)
            {
                return new OperationResult<IEnumerable<InstaImpression>>(Enumerable.Empty<InstaImpression>(),
                    OperationResultEnum.Failed);
            }
        }
    }
}
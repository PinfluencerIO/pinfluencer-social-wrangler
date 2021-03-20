using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinf.InstaService.BLL.Models.Insights;
using Pinf.InstaService.Bootstrapping.Services;
using Pinf.InstaService.Bootstrapping.Services.Enum;
using Pinf.InstaService.Bootstrapping.Services.Repositories;
using Pinf.InstaService.Crosscutting.CodeContracts;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class FacebookInstaImpressionsRepository : IInstaImpressionsRepository
    {
        private readonly FacebookContext _facebookContext;

        public FacebookInstaImpressionsRepository(FacebookContext facebookContext)
        {
            _facebookContext = facebookContext;
        }

        public OperationResult<IEnumerable<InstaImpression>> GetImpressions(string instaId)
        {
            try
            {
                var impressions = _facebookContext.Get($"{instaId}/insights", new RequestInsightParams
                {
                    metric = "impressions",
                    period = "day",
                    since = 1607650400,
                    until = 1610150400
                });

                var impressionsObj = JsonConvert.DeserializeObject<DataArray<Metric>>(impressions);

                new PostCondition().Evaluate(impressionsObj != null);

                return new OperationResult<IEnumerable<InstaImpression>>(
                    impressionsObj.Data.First().Insights
                        .Select(x => new InstaImpression(DateTime.Parse(x.Time), x.Value)),
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
using System.Linq;
using Pinf.InstaService.BLL.Models.Insights;
using Pinf.InstaService.Bootstrapping.Services;
using Pinf.InstaService.Bootstrapping.Services.Enum;
using Pinf.InstaService.Bootstrapping.Services.Repositories;

namespace Pinf.InstaService.BLL.InstagramFetcher.Services
{
    public class InstaInsightsCollectionService
    {
        private readonly IInstaImpressionsRepository _impressionsRepository;

        public InstaInsightsCollectionService(
            IInstaImpressionsRepository impressionsRepository
        )
        {
            _impressionsRepository = impressionsRepository;
        }

        public OperationResult<InstaInsightsCollection> GetUserInsights(string id)
        {
            var impressions = _impressionsRepository.GetImpressions(id);
            if (impressions.Status == OperationResultEnum.Success)
                return new OperationResult<InstaInsightsCollection>(new InstaInsightsCollection(impressions.Value),
                    OperationResultEnum.Success);
            return new OperationResult<InstaInsightsCollection>(new InstaInsightsCollection(
                Enumerable.Empty<InstaImpression>()
            ), OperationResultEnum.Failed);
        }
    }
}
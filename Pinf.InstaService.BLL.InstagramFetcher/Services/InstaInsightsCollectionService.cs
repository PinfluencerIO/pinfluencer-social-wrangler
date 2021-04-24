using System.Linq;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.Core.Repositories;
using Pinf.InstaService.BLL.Models.Insights;

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

        public OperationResult<InstaInsightsCollection> GetUserInsights( string id )
        {
            var impressions = _impressionsRepository.GetImpressions( id );
            if ( impressions.Status == OperationResultEnum.Success )
                return new OperationResult<InstaInsightsCollection>( new InstaInsightsCollection( impressions.Value ),
                    OperationResultEnum.Success );
            return new OperationResult<InstaInsightsCollection>( new InstaInsightsCollection(
                Enumerable.Empty<InstaImpression>( )
            ), OperationResultEnum.Failed );
        }
    }
}
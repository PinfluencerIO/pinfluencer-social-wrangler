﻿using System.Linq;
using BLL.Models.Insights;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;

namespace BLL.InstagramFetcher.Services
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BLL.InstagramFetcher.Validation;
using BLL.Models;
using Bootstrapping.Services.Repositories;
using Crosscutting.CodeContracts;

namespace BLL.InstagramFetcher.Factories
{
    public class InstaInsightsCollectionFactory
    {
        private readonly IInstaAudienceInsightsRepository _audienceInsightsRepository;
        private readonly ValidateInstaAudienceAgeRange _validateInstaAudienceAgeRange;
        private readonly IInstaImpressionsRepository _impressionsRepository;

        public InstaInsightsCollectionFactory(
            IInstaAudienceInsightsRepository audienceInsightsRepository,
            ValidateInstaAudienceAgeRange validateInstaAudienceAgeRange, IInstaImpressionsRepository impressionsRepository)
        {
            _audienceInsightsRepository = audienceInsightsRepository;
            _validateInstaAudienceAgeRange = validateInstaAudienceAgeRange;
            _impressionsRepository = impressionsRepository;
        }

        public OperationResult<InstaInsightsCollection> GetUserInsights(string id)
        {
            var genderAge = _audienceInsightsRepository.GetGenderAge(id);
            var country = _audienceInsightsRepository.GetCountry(id);
            var impressions = _impressionsRepository.GetImpressions(id);
            genderAge.Value.ToList().ForEach(x =>
            {
                _validateInstaAudienceAgeRange.AgeRange = x.Property.AgeRange;
                new Precondition().Evaluate(_validateInstaAudienceAgeRange.Validate());
            });
            return null;
        }
    }
}
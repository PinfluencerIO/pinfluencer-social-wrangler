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
        private readonly ValidateCountry _validateCountry;
        
        public InstaInsightsCollectionFactory(
            IInstaAudienceInsightsRepository audienceInsightsRepository,
            ValidateInstaAudienceAgeRange validateInstaAudienceAgeRange, 
            ValidateCountry validateCountry
        )
        {
            _audienceInsightsRepository = audienceInsightsRepository;
            _validateInstaAudienceAgeRange = validateInstaAudienceAgeRange;
            _validateCountry = validateCountry;
        }

        public InstaInsightsCollection GetUserInsights(string id)
        {
            var result = _audienceInsightsRepository.GetGenderAge(id);
            result.Value.ToList().ForEach(x =>
            {
                _validateInstaAudienceAgeRange.AgeRange = x.Property.AgeRange;
                new Precondition().Evaluate(_validateInstaAudienceAgeRange.Validate());
            });
            return null;
        }
    }
}
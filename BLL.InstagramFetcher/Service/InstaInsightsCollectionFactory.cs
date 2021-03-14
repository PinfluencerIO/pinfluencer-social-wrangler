using System;
using BLL.InstagramFetcher.Validation;
using BLL.Models;
using Bootstrapping.Services.Repositories;

namespace BLL.InstagramFetcher.Service
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
            throw new ArgumentException();
        }
    }
}
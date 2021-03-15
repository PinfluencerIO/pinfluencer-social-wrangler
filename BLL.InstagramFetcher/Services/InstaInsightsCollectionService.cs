using System.Linq;
using BLL.Models;
using BLL.Models.Insights;
using BLL.Models.Validation;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;
using Crosscutting.CodeContracts;

namespace BLL.InstagramFetcher.Services
{
    public class InstaInsightsCollectionService
    {
        private readonly IInstaAudienceInsightsRepository _audienceInsightsRepository;
        private readonly IInstaImpressionsRepository _impressionsRepository;
        private readonly ValidateInstaAudienceAgeRange _validateInstaAudienceAgeRange;

        public InstaInsightsCollectionService(
            IInstaAudienceInsightsRepository audienceInsightsRepository,
            IInstaImpressionsRepository impressionsRepository, 
            ValidateInstaAudienceAgeRange validateInstaAudienceAgeRange
        )
        {
            _audienceInsightsRepository = audienceInsightsRepository;
            _impressionsRepository = impressionsRepository;
            _validateInstaAudienceAgeRange = validateInstaAudienceAgeRange;
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
            if (
                genderAge.Status == OperationResultEnum.Success &&
                country.Status == OperationResultEnum.Success &&
                impressions.Status == OperationResultEnum.Success
            )
            {
                return new OperationResult<InstaInsightsCollection>(new InstaInsightsCollection(country.Value,genderAge.Value,impressions.Value),OperationResultEnum.Success);
            }
            return new OperationResult<InstaInsightsCollection>(new InstaInsightsCollection(
                Enumerable.Empty<InstaFollowersInsight<CountryProperty>>(),
                Enumerable.Empty<InstaFollowersInsight<GenderAgeProperty>>(),
                Enumerable.Empty<InstaImpression>()
            ), OperationResultEnum.Failed);
        }
    }
}
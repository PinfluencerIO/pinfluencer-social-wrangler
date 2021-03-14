using BLL.InstagramFetcher.Validation;
using Bootstrapping.Services.Repositories;
using Crosscutting.Testing.Extensions;
using NSubstitute;

namespace Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory
{
    public abstract class Given_A_InstaInsightsCollectionFactory : GivenWhenThen<global::BLL.InstagramFetcher.Factories.InstaInsightsCollectionFactory>
    {
        protected IInstaAudienceInsightsRepository MockAudienceInsightsRepository;
        protected IInstaImpressionsRepository MockImpressionsInsightsRepository;

        protected override void Given()
        {
            MockAudienceInsightsRepository = Substitute.For<IInstaAudienceInsightsRepository>();
            MockImpressionsInsightsRepository = Substitute.For<IInstaImpressionsRepository>();

            Sut = new global::BLL.InstagramFetcher.Factories.InstaInsightsCollectionFactory(
                MockAudienceInsightsRepository,
                new ValidateInstaAudienceAgeRange(),
                MockImpressionsInsightsRepository
            );
        }
    }
}
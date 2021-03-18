using Bootstrapping.Services.Repositories;
using Crosscutting.Testing.Extensions;
using NSubstitute;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService
{
    public abstract class
        Given_A_InstaInsightsCollectionService : GivenWhenThen<
            global::BLL.InstagramFetcher.Services.InstaInsightsCollectionService>
    {
        protected IInstaImpressionsRepository MockImpressionsInsightsRepository;

        protected override void Given()
        {
            MockImpressionsInsightsRepository = Substitute.For<IInstaImpressionsRepository>();

            Sut = new global::BLL.InstagramFetcher.Services.InstaInsightsCollectionService(
                MockImpressionsInsightsRepository
            );
        }
    }
}
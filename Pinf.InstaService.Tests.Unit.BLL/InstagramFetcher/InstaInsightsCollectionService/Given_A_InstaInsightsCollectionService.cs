using NSubstitute;
using Pinf.InstaService.Bootstrapping.Services.Repositories;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService
{
    public abstract class
        Given_A_InstaInsightsCollectionService : GivenWhenThen<
            global::Pinf.InstaService.BLL.InstagramFetcher.Services.InstaInsightsCollectionService>
    {
        protected IInstaImpressionsRepository MockImpressionsInsightsRepository;

        protected override void Given()
        {
            MockImpressionsInsightsRepository = Substitute.For<IInstaImpressionsRepository>();

            Sut = new global::Pinf.InstaService.BLL.InstagramFetcher.Services.InstaInsightsCollectionService(
                MockImpressionsInsightsRepository
            );
        }
    }
}
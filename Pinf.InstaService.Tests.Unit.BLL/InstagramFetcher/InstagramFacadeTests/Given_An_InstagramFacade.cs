using NSubstitute;
using Pinf.InstaService.BLL.Core.Repositories;
using Pinf.InstaService.BLL.InstagramFetcher.Services;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests
{
    public abstract class
        Given_An_InstagramFacade : GivenWhenThen<InstagramFacade>
    {
        protected IInstaImpressionsRepository MockImpressionsInsightsRepository;
        protected IInstaUserRepository MockInstaUserRepository;

        protected override void Given( )
        {
            MockImpressionsInsightsRepository = Substitute.For<IInstaImpressionsRepository>( );
            MockInstaUserRepository = Substitute.For<IInstaUserRepository>( );

            Sut = new InstagramFacade(
                MockImpressionsInsightsRepository,
                MockInstaUserRepository
            );
        }
    }
}
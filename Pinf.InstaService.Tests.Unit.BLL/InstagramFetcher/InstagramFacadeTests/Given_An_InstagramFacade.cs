using NSubstitute;
using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests
{
    public abstract class
        Given_An_InstagramFacade : GivenWhenThen<InstagramFacade>
    {
        protected IInstaImpressionsRepository MockImpressionsInsightsRepository;
        protected IInstaUserRepository MockInstaUserRepository;
        protected IInstaAudienceInsightsRepository MockInstaAudienceInsightsRepository;

        protected override void Given( )
        {
            
            MockImpressionsInsightsRepository = Substitute.For<IInstaImpressionsRepository>( );
            MockInstaUserRepository = Substitute.For<IInstaUserRepository>( );
            MockInstaAudienceInsightsRepository = Substitute.For<IInstaAudienceInsightsRepository>( );

            Sut = new InstagramFacade(
                MockImpressionsInsightsRepository,
                MockInstaUserRepository,
                MockInstaAudienceInsightsRepository
            );
        }
    }
}
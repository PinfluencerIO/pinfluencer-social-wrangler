using NSubstitute;
using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests
{
    public abstract class
        Given_An_InstagramFacade : DataGivenWhenThen<InstagramFacade>
    {
        protected IInstaImpressionsRepository MockImpressionsInsightsRepository;
        protected IInstaUserRepository MockInstaUserRepository;
        protected IInstaAudienceRepository MockInstaAudienceRepository;

        protected override void Given( )
        {
            base.Given( );
            
            MockImpressionsInsightsRepository = Substitute.For<IInstaImpressionsRepository>( );
            MockInstaUserRepository = Substitute.For<IInstaUserRepository>( );
            MockInstaAudienceRepository = Substitute.For<IInstaAudienceRepository>( );

            Sut = new InstagramFacade(
                MockImpressionsInsightsRepository,
                MockInstaUserRepository,
                MockInstaAudienceRepository
            );
        }
    }
}
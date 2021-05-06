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
        protected ISocialImpressionsRepository MockImpressionsInsightsRepository;
        protected ISocialUserRepository MockSocialUserRepository;
        protected ISocialAudienceRepository MockSocialAudienceRepository;

        protected override void Given( )
        {
            base.Given( );
            
            MockImpressionsInsightsRepository = Substitute.For<ISocialImpressionsRepository>( );
            MockSocialUserRepository = Substitute.For<ISocialUserRepository>( );
            MockSocialAudienceRepository = Substitute.For<ISocialAudienceRepository>( );

            Sut = new InstagramFacade(
                MockImpressionsInsightsRepository,
                MockSocialUserRepository,
                MockSocialAudienceRepository
            );
        }
    }
}
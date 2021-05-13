using NSubstitute;
using Pinfluencer.SocialWrangler.BLL.Facades;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests
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
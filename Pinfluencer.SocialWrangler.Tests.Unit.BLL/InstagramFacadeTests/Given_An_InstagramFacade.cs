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
        protected IInsightsSocialUserRepository InsightsSocialUserRepository;
        protected ISocialAudienceRepository MockSocialAudienceRepository;

        protected override void Given( )
        {
            base.Given( );
            
            MockImpressionsInsightsRepository = Substitute.For<ISocialImpressionsRepository>( );
            InsightsSocialUserRepository = Substitute.For<IInsightsSocialUserRepository>( );
            MockSocialAudienceRepository = Substitute.For<ISocialAudienceRepository>( );

            SUT = new InstagramFacade(
                MockImpressionsInsightsRepository,
                InsightsSocialUserRepository,
                MockSocialAudienceRepository
            );
        }
    }
}
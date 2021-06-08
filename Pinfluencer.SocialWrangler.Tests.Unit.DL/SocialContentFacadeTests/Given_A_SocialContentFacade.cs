using NSubstitute;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DL.Facades;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests
{
    public class Given_A_SocialContentFacade : DataGivenWhenThen<SocialContentFacade>
    {
        protected ISocialContentReachRepository MockSocialContentReachRepository;
        protected ISocialContentImpressionsRepository ImpressionsInsightsRepository;
        protected ISocialContentRepository MockSocialContentRepository;
        protected IInsightsSocialUserRepository MockSocialInsightsUserRepository;
        protected ISocialEngagementRepository MockSocialEngagementRepository;

        protected override void Given( )
        {
            base.Given( );
            ImpressionsInsightsRepository = Substitute.For<ISocialContentImpressionsRepository>( );
            MockSocialContentReachRepository = Substitute.For< ISocialContentReachRepository >( );
            MockSocialContentRepository = Substitute.For< ISocialContentRepository >( );
            MockSocialInsightsUserRepository = Substitute.For< IInsightsSocialUserRepository >( );
            MockSocialEngagementRepository = Substitute.For< ISocialEngagementRepository >( );
            SUT = new SocialContentFacade( MockSocialContentReachRepository, 
                MockDateTime, 
                ImpressionsInsightsRepository,
                MockSocialContentRepository,
                MockSocialInsightsUserRepository,
                MockSocialEngagementRepository );
        }
    }
}
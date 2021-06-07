using NSubstitute;
using Pinfluencer.SocialWrangler.DL.Facades;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests
{
    public abstract class
        Given_A_SocialFacade : DataGivenWhenThen<SocialFacade>
    {
        protected ISocialContentImpressionsRepository ImpressionsInsightsRepository;
        protected IInsightsSocialUserRepository InsightsSocialUserRepository;
        protected ISocialAudienceGenderAgeRepository MockSocialAudienceGenderAgeRepository;
        protected ISocialAudienceCountryRepository MockSocialAudienceCountryRepository;
        protected ISocialContentReachRepository MockSocialContentReachRepository;

        protected override void Given( )
        {
            base.Given( );

            ImpressionsInsightsRepository = Substitute.For<ISocialContentImpressionsRepository>( );
            InsightsSocialUserRepository = Substitute.For<IInsightsSocialUserRepository>( );
            MockSocialAudienceGenderAgeRepository = Substitute.For< ISocialAudienceGenderAgeRepository >( );
            MockSocialAudienceCountryRepository = Substitute.For< ISocialAudienceCountryRepository >( );
            MockSocialContentReachRepository = Substitute.For< ISocialContentReachRepository >( );

            SUT = new SocialFacade( ImpressionsInsightsRepository,
                InsightsSocialUserRepository,
                MockDateTime,
                MockSocialAudienceGenderAgeRepository,
                MockSocialAudienceCountryRepository,
                MockSocialContentReachRepository );
        }
    }
}
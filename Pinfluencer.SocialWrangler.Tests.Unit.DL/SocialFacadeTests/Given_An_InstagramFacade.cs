using NSubstitute;
using Pinfluencer.SocialWrangler.DL.Facades;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests
{
    public abstract class
        Given_An_InstagramFacade : DataGivenWhenThen<SocialFacade>
    {
        protected ISocialContentImpressionsRepository ImpressionsInsightsRepository;
        protected IInsightsSocialUserRepository InsightsSocialUserRepository;
        protected ISocialAudienceRepository MockSocialAudienceRepository;

        protected override void Given( )
        {
            base.Given( );

            ImpressionsInsightsRepository = Substitute.For<ISocialContentImpressionsRepository>( );
            InsightsSocialUserRepository = Substitute.For<IInsightsSocialUserRepository>( );
            MockSocialAudienceRepository = Substitute.For<ISocialAudienceRepository>( );

            SUT = new SocialFacade( ImpressionsInsightsRepository,
                InsightsSocialUserRepository,
                MockSocialAudienceRepository,
                MockDateTime );
        }
    }
}
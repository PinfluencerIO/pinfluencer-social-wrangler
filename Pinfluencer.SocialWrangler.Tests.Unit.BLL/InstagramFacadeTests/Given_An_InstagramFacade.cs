using NSubstitute;
using Pinfluencer.SocialWrangler.DL.Facades;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests
{
    public abstract class
        Given_An_InstagramFacade : DataGivenWhenThen<InstagramFacade>
    {
        protected ISocialImpressionsRepository ImpressionsInsightsRepository;
        protected IInsightsSocialUserRepository InsightsSocialUserRepository;
        protected ISocialAudienceRepository MockSocialAudienceRepository;

        protected override void Given( )
        {
            base.Given( );

            ImpressionsInsightsRepository = Substitute.For<ISocialImpressionsRepository>( );
            InsightsSocialUserRepository = Substitute.For<IInsightsSocialUserRepository>( );
            MockSocialAudienceRepository = Substitute.For<ISocialAudienceRepository>( );

            SUT = new InstagramFacade(
                ImpressionsInsightsRepository,
                InsightsSocialUserRepository,
                MockSocialAudienceRepository
            );
        }
    }
}
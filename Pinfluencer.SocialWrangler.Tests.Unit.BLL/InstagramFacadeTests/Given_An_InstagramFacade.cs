using NSubstitute;
using Pinfluencer.SocialWrangler.BLL.Facades;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Social;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;

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
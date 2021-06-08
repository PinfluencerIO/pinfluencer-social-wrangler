using NSubstitute;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.DL.Facades;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests
{
    public class Given_An_AudienceFacade : DataGivenWhenThen<AudienceFacade>
    {
        protected ISocialAudienceFacade MockSocialAudienceFacade;
        protected ISocialContentFacade MockSocialContentFacade;
        protected ISocialInsightUserFacade MockSocialInsightsUserFacade;

        protected override void Given( )
        {
            base.Given( );
            MockSocialAudienceFacade = Substitute.For<ISocialAudienceFacade>( );
            MockSocialContentFacade = Substitute.For<ISocialContentFacade>( );
            MockSocialInsightsUserFacade = Substitute.For<ISocialInsightUserFacade>( );
            SUT = new AudienceFacade( MockSocialAudienceFacade,
                MockSocialContentFacade,
                MockSocialInsightsUserFacade );
        }
    }
}
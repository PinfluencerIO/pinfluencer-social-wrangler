using NSubstitute;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DL.Facades;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialAudienceFacadeTests
{
    public class Given_A_SocialAudienceFacade : DataGivenWhenThen<SocialAudienceFacade>
    {
        protected ISocialAudienceGenderAgeRepository MockSocialAudienceGenderAgeRepository;
        protected ISocialAudienceCountryRepository MockSocialAudienceCountryRepository;

        protected override void Given( )
        {
            base.Given( );
            MockSocialAudienceGenderAgeRepository = Substitute.For< ISocialAudienceGenderAgeRepository >( );
            MockSocialAudienceCountryRepository = Substitute.For< ISocialAudienceCountryRepository >( );

            SUT = new SocialAudienceFacade( MockSocialAudienceCountryRepository,
                MockSocialAudienceGenderAgeRepository );
        }
    }
}
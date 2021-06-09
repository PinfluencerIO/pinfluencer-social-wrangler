using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceCountryRepositoryTests
{
    public class Given_An_InstagramAudienceCountryRepository : DataGivenWhenThen<InstagramAudienceCountryRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new InstagramAudienceCountryRepository( CountryGetter, MockFacebookDataHandler );
        }
    }
}
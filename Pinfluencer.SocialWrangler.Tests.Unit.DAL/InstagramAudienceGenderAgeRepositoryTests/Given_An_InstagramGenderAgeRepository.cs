using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceGenderAgeRepositoryTests
{
    public class Given_An_InstagramGenderAgeRepository : DataGivenWhenThen<InstagramAudienceGenderAgeRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new InstagramAudienceGenderAgeRepository( MockFacebookDataHandler );
        }
    }
}
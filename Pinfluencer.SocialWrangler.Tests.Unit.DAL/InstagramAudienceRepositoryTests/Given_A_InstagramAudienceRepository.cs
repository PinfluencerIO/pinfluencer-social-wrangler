using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Instagram.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests
{
    public class Given_A_InstagramAudienceRepository : DataGivenWhenThen<InstagramAudienceRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            Sut = new InstagramAudienceRepository( new FacebookContext{ FacebookClient = MockFacebookClient }, MockLogger, CountryGetter );
        }
    }
}
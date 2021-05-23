using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests
{
    public class Given_A_InstagramAudienceRepository : DataGivenWhenThen<InstagramAudienceRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new InstagramAudienceRepository( FacebookDecorator, MockLogger, CountryGetter );
        }
    }
}
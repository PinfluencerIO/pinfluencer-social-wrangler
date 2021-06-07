using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramEngagementRepositoryTests
{
    public class Given_An_InstagramEngagementRepository : DataGivenWhenThen<InstagramEngagementRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new InstagramEngagementRepository( MockFacebookDataHandler );
        }
    }
}
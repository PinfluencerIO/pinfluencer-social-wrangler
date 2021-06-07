using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentRepositoryTests
{
    public class Given_An_InstagramContentRepository : DataGivenWhenThen<InstagramContentRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new InstagramContentRepository( MockFacebookDataHandler );
        }
    }
}
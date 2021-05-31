using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentImpressionsRepositoryTests
{
    public class Given_An_InstagramContentImpressionsRepository : DataGivenWhenThen<InstagramContentImpressionsRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new InstagramContentImpressionsRepository( MockFacebookDataHandler );
        }
    }
}
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramUserRepositoryTests
{
    public abstract class Given_A_InstagramUserRepository : DataGivenWhenThen<InstagramUserRepository>
    {
        protected override void Given( )
        {
            base.Given( );

            SUT = new InstagramUserRepository(
                FacebookDecorator,
                MockFacebookDataHandler
            );
        }
    }
}
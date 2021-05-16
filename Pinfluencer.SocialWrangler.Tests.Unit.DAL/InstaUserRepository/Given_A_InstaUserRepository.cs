using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaUserRepository
{
    public abstract class Given_A_InstaUserRepository : DataGivenWhenThen<InstagramUserRepository>
    {
        protected override void Given( )
        {
            base.Given( );

            Sut = new InstagramUserRepository(
                FacebookContext,
                MockLogger
            );
        }
    }
}
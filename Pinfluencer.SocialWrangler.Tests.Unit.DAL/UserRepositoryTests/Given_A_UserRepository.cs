using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests
{
    public abstract class Given_A_UserRepository : DataGivenWhenThen<UserRepository>
    {
        protected override void Given( )
        {
            base.Given( );

            SUT = new UserRepository( MockBubbleDataHandler );
        }
    }
}
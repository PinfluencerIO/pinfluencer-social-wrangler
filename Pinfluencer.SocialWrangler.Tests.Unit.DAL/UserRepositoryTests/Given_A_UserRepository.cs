using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests
{
    public abstract class Given_A_UserRepository : DataGivenWhenThen<BubbleUserRepository>
    {
        protected override void Given( )
        {
            base.Given( );

            SUT = new BubbleUserRepository( MockBubbleDataHandler );
        }
    }
}
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookTokenRepositoryTests.GetInstagramTokenTests
{
    public class Given_A_FacebookTokenRepository : DataGivenWhenThen<FacebookTokenRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new FacebookTokenRepository( MockLogger, MockAuthServiceManagementClientDecorator );
        }
    }
}
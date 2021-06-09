using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookTokenRepositoryTests.GetInstagramTokenTests
{
    public class Given_A_FacebookTokenRepository : DataGivenWhenThen<Auth0FacebookTokenRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new Auth0FacebookTokenRepository( MockLogger, MockAuthServiceManagementClientDecorator );
        }
    }
}
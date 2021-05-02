using Facebook;
using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests
{
    public class Given_A_InstagramAudienceRepository : PinfluencerGivenWhenThen<InstagramAudienceRepository>
    {
        protected FacebookClient MockFacebookClient;
        
        protected override void Given( )
        {
            base.Given( );
            MockFacebookClient = Substitute.For<FacebookClient>( );
            Sut = new InstagramAudienceRepository( new FacebookContext{ FacebookClient = MockFacebookClient } );
        }
    }
}
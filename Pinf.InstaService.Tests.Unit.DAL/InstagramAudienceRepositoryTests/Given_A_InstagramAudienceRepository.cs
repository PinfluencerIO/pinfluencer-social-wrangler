using Facebook;
using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.DAL.Instagram;
using Pinf.InstaService.DAL.Instagram.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests
{
    public class Given_A_InstagramAudienceRepository : GivenWhenThen<InstagramAudienceRepository>
    {
        protected FacebookClient MockFacebookClient;

        protected override void Given( )
        {
            MockFacebookClient = Substitute.For<FacebookClient>( );

            Sut = new InstagramAudienceRepository(
                new FacebookContext
                {
                    FacebookClient = MockFacebookClient
                }
            );
        }
    }
}
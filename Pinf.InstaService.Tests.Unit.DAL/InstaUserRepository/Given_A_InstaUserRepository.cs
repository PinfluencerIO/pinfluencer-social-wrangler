using Facebook;
using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.DAL.Instagram;
using Pinf.InstaService.DAL.Instagram.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaUserRepository
{
    public abstract class Given_A_InstaUserRepository : GivenWhenThen<FacebookInstaUserRepository>
    {
        protected FacebookClient MockFacebookClient;

        protected override void Given()
        {
            MockFacebookClient = Substitute.For<FacebookClient>();

            Sut = new FacebookInstaUserRepository(
                new FacebookContext
                {
                    FacebookClient = MockFacebookClient
                }
            );
        }
    }
}
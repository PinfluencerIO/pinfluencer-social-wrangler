using Crosscutting.Testing.Extensions;
using DAL.Instagram;
using DAL.Instagram.Repositories;
using Facebook;
using NSubstitute;

namespace Tests.Unit.DAL.InstaUserRepository
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
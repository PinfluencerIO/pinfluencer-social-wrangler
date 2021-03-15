using Crosscutting.Testing.Extensions;
using DAL.Instagram;
using DAL.Instagram.Repositories;
using Facebook;
using NSubstitute;

namespace Tests.Unit.DAL.InstaImpressionsRepository
{
    public class Given_A_InstaImpressionsRepository : GivenWhenThen<FacebookInstaImpressionsRepository>
    {
        protected FacebookClient MockFacebookClient;

        protected override void Given()
        {
            MockFacebookClient = Substitute.For<FacebookClient>();

            Sut = new FacebookInstaImpressionsRepository(
                new FacebookInstagramDataContext(
                    MockFacebookClient
                )
            );
        }
    }
}
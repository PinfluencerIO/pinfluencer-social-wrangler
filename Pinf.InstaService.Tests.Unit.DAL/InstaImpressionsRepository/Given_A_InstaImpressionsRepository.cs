using Facebook;
using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.DAL.Instagram;
using Pinf.InstaService.DAL.Instagram.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaImpressionsRepository
{
    public class Given_A_InstaImpressionsRepository : GivenWhenThen<FacebookInstaImpressionsRepository>
    {
        protected FacebookClient MockFacebookClient;

        protected override void Given()
        {
            MockFacebookClient = Substitute.For<FacebookClient>();

            Sut = new FacebookInstaImpressionsRepository(
                new FacebookContext
                {
                    FacebookClient = MockFacebookClient
                }
            );
        }
    }
}
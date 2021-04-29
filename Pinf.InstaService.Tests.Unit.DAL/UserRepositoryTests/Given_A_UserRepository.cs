using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Facebook;
using NSubstitute;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.UserManagement;
using Pinf.InstaService.DAL.UserManagement.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests
{
    public abstract class Given_A_UserRepository : GivenWhenThen<UserRepository>
    {
        protected const string BubbleDomain = "https://mobile-pinfluencer.bubbleapps.io/version-test/api/1.1/obj";
        protected const string TestId = "1234";
        protected IManagementConnection MockAuth0ManagementApiConnection;
        protected IBubbleClient MockBubbleClient;
        protected User TestUser;
        protected FacebookClient MockFacebookClient;

        protected override void Given( )
        {
            MockAuth0ManagementApiConnection = Substitute.For<IManagementConnection>( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );
            MockFacebookClient = Substitute.For<FacebookClient>( );

            Sut = new UserRepository(
                new Auth0Context
                {
                    ManagementApiClient = new ManagementApiClient( "token", "domain", MockAuth0ManagementApiConnection )
                },
                MockBubbleClient,
                new FacebookContext
                {
                    FacebookClient = MockFacebookClient
                }
            );
        }
    }
}
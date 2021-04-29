using System;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Facebook;
using NSubstitute;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.Crosscutting.Utils;
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
        protected IDateTimeAdapter MockDateTime;
        protected Core.Models.User.User MockUser;

        //TODO: REFACTOR OUT TIME DEPENDANT TESTS
        protected override void Given( )
        {
            MockDateTime = Substitute.For<IDateTimeAdapter>( );
            MockAuth0ManagementApiConnection = Substitute.For<IManagementConnection>( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );
            MockFacebookClient = Substitute.For<FacebookClient>( );
            MockUser = new Core.Models.User.User( MockDateTime );

            MockDateTime
                .Now( )
                .Returns( new DateTime( 2021, 4, 29 ) );
            
            Sut = new UserRepository(
                new Auth0Context
                {
                    ManagementApiClient = new ManagementApiClient( "token", "domain", MockAuth0ManagementApiConnection )
                },
                MockBubbleClient,
                new FacebookContext
                {
                    FacebookClient = MockFacebookClient
                },
                MockUser
            );
        }
    }
}
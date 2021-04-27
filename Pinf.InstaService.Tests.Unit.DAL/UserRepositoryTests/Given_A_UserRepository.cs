using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.Crosscutting.Web;
using Pinf.InstaService.DAL.UserManagement;
using Pinf.InstaService.DAL.UserManagement.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests
{
    public abstract class Given_A_UserRepository : GivenWhenThen<UserRepository>
    {
        protected const string BubbleDomain = "https://mobile-pinfluencer.bubbleapps.io/version-test/api/1.1/obj";
        protected const string TestId = "1234";
        protected IManagementConnection MockAuth0ManagementApiConnection;
        protected User TestUser;
        protected IBubbleClient MockBubbleClient;

        protected override void Given( )
        {
            MockAuth0ManagementApiConnection = Substitute.For<IManagementConnection>( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );
            
            Sut = new UserRepository(
                new Auth0Context
                {
                    ManagementApiClient = new ManagementApiClient( "token", "domain", MockAuth0ManagementApiConnection )
                },
                MockBubbleClient
            );
        }
    }
}
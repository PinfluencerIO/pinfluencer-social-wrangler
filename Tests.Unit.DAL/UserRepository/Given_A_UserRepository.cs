using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Crosscutting.Testing.Extensions;
using DAL.UserManagement;
using DAL.UserManagement.Repositories;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Unit.DAL.UserRepository
{
    public abstract class Given_A_UserRepository : GivenWhenThen<Auth0UserRepository>
    {
        protected const string TestId = "1234";
        protected IManagementConnection MockAuth0ManagementApiConnection;
        protected User TestUser;

        protected override void Given()
        {
            MockAuth0ManagementApiConnection = Substitute.For<IManagementConnection>();

            Sut = new Auth0UserRepository(
                new Auth0Context
                {
                    ManagementApiClient = new ManagementApiClient("token", "domain", MockAuth0ManagementApiConnection)
                }
            );
        }

        protected override void When()
        {
            MockAuth0ManagementApiConnection
                .GetAsync<User>(Arg.Any<Uri>(), Arg.Any<IDictionary<string, string>>(), Arg.Any<JsonConverter[]>())
                .Returns(Task.FromResult(TestUser));
        }

        [Test]
        public void Then_Get_User_Is_Called_Once()
        {
            MockAuth0ManagementApiConnection
                .Received(1)
                .GetAsync<User>(Arg.Any<Uri>(), Arg.Any<IDictionary<string, string>>(), Arg.Any<JsonConverter[]>());
        }

        [Test]
        //TODO: flaky test
        public void Then_Valid_User_Is_Retrieved()
        {
            MockAuth0ManagementApiConnection
                .Received()
                .GetAsync<User>(Arg.Is<Uri>(x => x.AbsolutePath.Contains(TestId)),
                    Arg.Any<IDictionary<string, string>>(), Arg.Any<JsonConverter[]>());
        }
    }
}
using System;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Facebook;
using NSubstitute;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.UserManagement;
using Pinf.InstaService.DAL.UserManagement.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests
{
    public abstract class Given_A_UserRepository : DataGivenWhenThen<UserRepository>
    {
        protected const string BubbleDomain = "https://mobile-pinfluencer.bubbleapps.io/version-test/api/1.1/obj";
        protected const string TestId = "1234";
        protected IBubbleClient MockBubbleClient;
        protected User TestUser;

        //TODO: REFACTOR OUT TIME DEPENDANT TESTS
        protected override void Given( )
        {
            base.Given( );
            MockBubbleClient = Substitute.For<IBubbleClient>( );

            CurrentTime = new DateTime( 2021, 4, 29 );
            
            Sut = new UserRepository(
                Auth0Context,
                MockBubbleClient,
                FacebookContext,
                User,
                MockLogger
            );
        }
    }
}
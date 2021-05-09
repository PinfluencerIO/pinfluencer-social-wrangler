using System;
using Auth0.ManagementApi.Models;
using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Pinfluencer.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests
{
    public abstract class Given_A_UserRepository : DataGivenWhenThen<UserRepository>
    {
        protected const string BubbleDomain = "https://mobile-pinfluencer.bubbleapps.io/version-test/api/1.1/obj";
        protected const string TestId = "1234";
        protected User TestUser;

        //TODO: REFACTOR OUT TIME DEPENDANT TESTS
        protected override void Given( )
        {
            base.Given( );

            CurrentTime = new DateTime( 2021, 4, 29 );
            
            Sut = new UserRepository(
                Auth0Context,
                FacebookContext,
                User,
                MockLogger,
                MockBubbleDataHandler
            );
        }
    }
}
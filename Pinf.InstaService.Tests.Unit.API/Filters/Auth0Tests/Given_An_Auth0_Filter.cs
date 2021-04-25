using System;
using System.IO;
using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.API.InstaFetcher.Options;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.DAL.UserManagement;

namespace Pinf.InstaService.Tests.Unit.API.Filters.Auth0Tests
{
    //TODO: add tests for failing to parse URIs
    public abstract class
        Given_An_Auth0_Filter : AspActionFilterGivenWhenThen<Auth0Attribute>
    {
        protected const string TestToken = "123456789";
        private Auth0Context _mockAuth0Context;
        protected IAuthenticationConnection MockAuthenticationConnection;
        private IConfiguration _mockConfiguration;
        private IManagementConnection _mockManagementConnection;

        protected override void Given( )
        {
            base.Given( );
            _mockAuth0Context = Substitute.For<Auth0Context>( );
            _mockManagementConnection = Substitute.For<IManagementConnection>( );
            MockAuthenticationConnection = Substitute.For<IAuthenticationConnection>( );

            Sut = new Auth0Attribute( _mockAuth0Context, _mockConfiguration, _mockManagementConnection, MockAuthenticationConnection );
        }

        protected void SetupConfiguration( AppOptions appOptions )
        {
            _mockConfiguration = FakeConfiguration.GetFake( appOptions );
        }

        protected static readonly AppOptions DefaultAppOptions = new AppOptions
        {
            Auth0 = new Auth0Options
            {
                Domain = "test_domain",
                Id = "test_id",
                ManagementDomain = "test_man_domain",
                Secret = "test_secret"
            }
        };

        protected static AppOptions ModifyDefaultAppOptions( Func<AppOptions, AppOptions> appOptionsModifer )
        {
            return appOptionsModifer( DefaultAppOptions );
        }
    }
}
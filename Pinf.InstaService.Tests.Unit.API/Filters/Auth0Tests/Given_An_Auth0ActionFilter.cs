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
    //TODO: add tests for invalid object passed into app settings options dto
    public abstract class Given_An_Auth0ActionFilter : AspActionFilterGivenWhenThen<Auth0ActionFilter>
    {
        protected const string TestToken = "123456789";
        private Auth0Context _mockAuth0Context;
        protected IAuthenticationConnection MockAuthenticationConnection;
        private IConfiguration _mockConfiguration;
        private IManagementConnection _mockManagementConnection;

        protected override void Given( )
        {
            base.Given( );
            _mockAuth0Context = new Auth0Context( );
            _mockManagementConnection = Substitute.For<IManagementConnection>( );
            MockAuthenticationConnection = Substitute.For<IAuthenticationConnection>( );

            SetupConfiguration( OverridableAppOptions );
            Sut = new Auth0ActionFilter( _mockAuth0Context, _mockConfiguration, _mockManagementConnection, MockAuthenticationConnection );
        }

        private void SetupConfiguration( AppOptions appOptions )
        {
            _mockConfiguration = FakeConfiguration.GetFake( appOptions );
        }

        private static AppOptions DefaultAppOptions => new AppOptions
        {
            Auth0 = new Auth0Options
            {
                Domain = "pinfluencer.eu.auth0.com",
                Id = "test_id",
                ManagementDomain = "https://pinfluencer.eu.auth0.com/api/v2/",
                Secret = "test_secret"
            }
        };

        protected virtual AppOptions OverridableAppOptions => DefaultAppOptions;

        protected static AppOptions ModifyDefaultAppOptions( Func<AppOptions, AppOptions> appOptionsModifer )
        {
            return appOptionsModifer( DefaultAppOptions );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
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
        protected const string TestDomain = "pinfluencer.eu.auth0.com";
        protected const string TestId = "test_id";
        protected const string TestManagementDomain = "https://pinfluencer.eu.auth0.com/api/v2/";
        protected const string TestSecret = "test_secret";
        private IConfiguration _mockConfiguration;
        private IManagementConnection _mockManagementConnection;

        protected Auth0Context MockAuth0Context;
        protected IAuthenticationConnection MockAuthenticationConnection;

        private static AppOptions DefaultAppOptions => new AppOptions
        {
            Auth0 = new Auth0Options
            {
                Domain = TestDomain,
                Id = TestId,
                ManagementDomain = TestManagementDomain,
                Secret = TestSecret
            }
        };

        protected virtual AppOptions OverridableAppOptions => DefaultAppOptions;

        protected override void Given( )
        {
            base.Given( );
            MockAuth0Context = new Auth0Context( );
            _mockManagementConnection = Substitute.For<IManagementConnection>( );
            MockAuthenticationConnection = Substitute.For<IAuthenticationConnection>( );

            SetupConfiguration( OverridableAppOptions );
            Sut = new Auth0ActionFilter( MockAuth0Context, _mockConfiguration, _mockManagementConnection,
                MockAuthenticationConnection );
        }

        private void SetupConfiguration( AppOptions appOptions )
        {
            _mockConfiguration = FakeConfiguration.GetFake( appOptions );
        }

        protected static AppOptions ModifyDefaultAppOptions( Func<AppOptions, AppOptions> appOptionsModifer )
        {
            return appOptionsModifer( DefaultAppOptions );
        }

        protected void TokenWasFetchedOnce( )
        {
            MockAuthenticationConnection
                .Received( 1 )
                .SendAsync<AccessTokenResponse>(
                    Arg.Any<HttpMethod>( ),
                    Arg.Any<Uri>( ),
                    Arg.Any<object>( ),
                    Arg.Any<IDictionary<string, string>>( )
                );
        }

        protected void TokenWasFetchedWithValidBody( )
        {
            MockAuthenticationConnection
                .Received( )
                .SendAsync<AccessTokenResponse>(
                    Arg.Any<HttpMethod>( ),
                    Arg.Any<Uri>( ),
                    Arg.Is<Dictionary<string, string>>( o => o.SequenceEqual( new Dictionary<string, string>
                    {
                        { "grant_type", "client_credentials" },
                        { "client_id", TestId },
                        { "client_secret", TestSecret },
                        { "audience", TestManagementDomain }
                    } ) ),
                    Arg.Any<IDictionary<string, string>>( )
                );
        }
    }
}
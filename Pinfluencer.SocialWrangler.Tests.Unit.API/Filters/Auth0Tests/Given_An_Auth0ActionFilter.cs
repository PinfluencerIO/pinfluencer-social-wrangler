using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Pinfluencer.SocialWrangler.API.Filters;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.Auth0Tests
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

        protected IAuthServiceManagementClientDecorator MockAuth0ManagementClientDecorator;
        protected IAuthServiceAuthenticationClientDecoratorFactory MockAuth0AuthenticationFactory;
        protected IAuthServiceAuthenticationClientDecorator MockAuth0AuthenticationClient;

        private static AppOptions DefaultAppOptions => new AppOptions
        {
            AuthService = new AuthServiceOptions
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
            MockAuth0ManagementClientDecorator = Substitute.For<IAuthServiceManagementClientDecorator>( );
            MockAuth0AuthenticationFactory = Substitute.For<IAuthServiceAuthenticationClientDecoratorFactory>( );
            MockAuth0AuthenticationClient = Substitute.For<IAuthServiceAuthenticationClientDecorator>( );
            MockAuth0AuthenticationFactory
                .Factory( Arg.Any<string>( ) )
                .Returns( MockAuth0AuthenticationClient );

            SetupConfiguration( OverridableAppOptions );
            SUT = new Auth0ActionFilter( MockAuth0ManagementClientDecorator, _mockConfiguration,
                MockAuth0AuthenticationFactory, MvcAdapter );
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
            MockAuth0AuthenticationFactory
                .Received( 1 )
                .Factory( Arg.Any<string>( ) );
            MockAuth0AuthenticationClient
                .Received( 1 )
                .GetToken( Arg.Any<( string, string, string )>( ) );
        }

        protected void TokenWasFetchedWithValidBody( )
        {
            MockAuth0AuthenticationFactory
                .Received( )
                .Factory( TestDomain );
            MockAuth0AuthenticationClient
                .Received( )
                .GetToken( ( TestId, TestSecret, TestManagementDomain ) );
        }
    }
}
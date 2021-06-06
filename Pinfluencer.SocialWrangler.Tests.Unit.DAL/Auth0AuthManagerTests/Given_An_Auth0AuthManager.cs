using System;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories;
using Pinfluencer.SocialWrangler.DAL.Facebook.Managers;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Auth0AuthManagerTests
{
    //TODO: add tests for failing to parse URIs
    //TODO: add tests for invalid object passed into app settings options dto
    public abstract class Given_An_Auth0AuthManager : DataGivenWhenThen<Auth0AuthManager>
    {
        protected const string TestToken = "123456789";
        protected const string TestDomain = "pinfluencer.eu.auth0.com";
        protected const string TestId = "test_id";
        protected const string TestManagementDomain = "https://pinfluencer.eu.auth0.com/api/v2/";
        protected const string TestSecret = "test_secret";
        private IConfigurationAdapter _mockConfiguration;
        protected Result Result;

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
            _mockConfiguration = Substitute.For<IConfigurationAdapter>( );

            SetupConfiguration( OverridableAppOptions );
            SUT = new Auth0AuthManager( _mockConfiguration,
                MockAuth0AuthenticationFactory,
                MockAuth0ManagementClientDecorator );
        }

        private void SetupConfiguration( AppOptions appOptions )
        {
            _mockConfiguration
                .Get<AppOptions>(  )
                .Returns( appOptions );
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
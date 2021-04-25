using System;
using System.Collections.Generic;
using System.Net.Http;
using Auth0.AuthenticationApi.Models;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.API.InstaFetcher.Options;
using Pinf.InstaService.Tests.Unit.API.Filters.Auth0Tests.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Filters.Auth0Tests
{
    [ TestFixtureSource( nameof( ConfigurationData ) ) ]
    public class When_Configuration_Value_Is_Empty : When_Error_Occurs
    {
        private static IEnumerable<AppOptions> ConfigurationData( ) => new [ ]
        {
            ModifyDefaultAppOptions( options =>
            {
                options.Auth0.Domain = default;
                return options;
            } ),
            ModifyDefaultAppOptions( options =>
            {
                options.Auth0.Id = default;
                return options;
            } ),
            ModifyDefaultAppOptions( options =>
            {
                options.Auth0.Secret = default;
                return options;
            } ),
            ModifyDefaultAppOptions( options =>
            {
                options.Auth0.ManagementDomain = default;
                return options;
            } )
        };

        protected override AppOptions OverridableAppOptions { get; }

        public When_Configuration_Value_Is_Empty( AppOptions appOptions ) { OverridableAppOptions = appOptions; }

        protected override void When( )
        {
            base.When( );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }
        
        [ Test ]
        public void Then_Token_Is_Not_Fetched( )
        {
            MockAuthenticationConnection
                .DidNotReceive( )
                .SendAsync<AccessTokenResponse>(
                    Arg.Any<HttpMethod>( ),
                    Arg.Any<Uri>( ),
                    Arg.Any<object>( ),
                    Arg.Any<IDictionary<string, string>>( )
                );
        }
    }
}
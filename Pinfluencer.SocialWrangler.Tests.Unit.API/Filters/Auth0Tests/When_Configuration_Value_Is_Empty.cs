using System;
using System.Collections.Generic;
using System.Net.Http;
using Auth0.AuthenticationApi.Models;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.Auth0Tests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.Auth0Tests
{
    [ TestFixtureSource( nameof( ConfigurationData ) ) ]
    public class When_Configuration_Value_Is_Empty : When_Error_Occurs
    {
        private static IEnumerable<AppOptions> ConfigurationData( )
        {
            return new [ ]
            {
                ModifyDefaultAppOptions( options =>
                {
                    options.AuthService.Domain = default;
                    return options;
                } ),
                ModifyDefaultAppOptions( options =>
                {
                    options.AuthService.Id = default;
                    return options;
                } ),
                ModifyDefaultAppOptions( options =>
                {
                    options.AuthService.Secret = default;
                    return options;
                } ),
                ModifyDefaultAppOptions( options =>
                {
                    options.AuthService.ManagementDomain = default;
                    return options;
                } )
            };
        }

        protected override AppOptions OverridableAppOptions { get; }

        public When_Configuration_Value_Is_Empty( AppOptions appOptions ) { OverridableAppOptions = appOptions; }

        protected override void When( )
        {
            base.When( );
            SUT.OnActionExecuting( MockActionExecutingContext );
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
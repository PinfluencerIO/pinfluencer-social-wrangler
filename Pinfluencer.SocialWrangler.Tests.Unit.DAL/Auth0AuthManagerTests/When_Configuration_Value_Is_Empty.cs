using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.Auth0AuthManagerTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Auth0AuthManagerTests
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
            Result = SUT.Initialize( );
        }

        [ Test ]
        public void Then_Token_Is_Not_Fetched( )
        {
            MockAuth0AuthenticationFactory
                .DidNotReceive( )
                .Factory( Arg.Any<string>( ) );
            MockAuth0AuthenticationClient
                .DidNotReceive( )
                .GetToken( Arg.Any< ( string, string, string )>( ) );
        }
    }
}
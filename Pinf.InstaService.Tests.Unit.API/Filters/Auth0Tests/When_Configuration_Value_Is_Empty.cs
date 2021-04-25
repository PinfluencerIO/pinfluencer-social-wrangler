using System.Collections.Generic;
using NUnit.Framework;
using Pinf.InstaService.API.InstaFetcher.Options;
using Pinf.InstaService.Tests.Unit.API.Filters.Auth0Tests.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Filters.Auth0Tests
{
    [ TestFixtureSource( nameof( ConfigurationData ) ) ]
    public class When_Configuration_Value_Is_Empty : When_Error_Occurs
    {
        private readonly AppOptions _appOptions;

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

        public When_Configuration_Value_Is_Empty( AppOptions appOptions ) { _appOptions = appOptions; }

        protected override void When( )
        {
            base.When( );
            SetupConfiguration( _appOptions );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }
    }
}
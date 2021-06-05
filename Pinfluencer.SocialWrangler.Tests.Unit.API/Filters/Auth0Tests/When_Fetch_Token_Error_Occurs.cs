using System;
using System.Collections.Generic;
using System.Net.Http;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.Auth0Tests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.Auth0Tests
{
    public class When_Fetch_Token_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockAuth0AuthenticationClient
                .GetToken( Arg.Any< ( string, string, string )>( ) )
                .Throws<ErrorApiException>( );
            SUT.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Token_Is_Fetched_Once( ) { TokenWasFetchedOnce( ); }

        [ Test ]
        public void Then_Token_Is_Fetched_With_Valid_Body( ) { TokenWasFetchedWithValidBody( ); }
    }
}
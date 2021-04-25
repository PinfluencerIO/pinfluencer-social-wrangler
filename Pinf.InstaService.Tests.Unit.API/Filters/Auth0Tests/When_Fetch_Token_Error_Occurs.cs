using System;
using System.Collections.Generic;
using System.Net.Http;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Pinf.InstaService.Tests.Unit.API.Filters.Auth0Tests.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Filters.Auth0Tests
{
    public class When_Fetch_Token_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockAuthenticationConnection
                .SendAsync<AccessTokenResponse>(
                    Arg.Any<HttpMethod>( ),
                    Arg.Any<Uri>( ),
                    Arg.Any<object>( ),
                    Arg.Any<IDictionary<string, string>>( )
                )
                .Throws<ErrorApiException>( );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Tests.Unit.API.Auth0Middlware.Shared;

namespace Tests.Unit.API.Auth0Middlware
{
    public class When_Fetch_Token_Error_Occurs : When_Error_Occurs
    {
        protected override void When()
        {
            AddDefaultConfiguration();
            SetConfiguration();

            MockAuthenticationConnection
                .SendAsync<AccessTokenResponse>(
                    Arg.Any<HttpMethod>(),
                    Arg.Any<Uri>(),
                    Arg.Any<object>(),
                    Arg.Any<IDictionary<string, string>>()
                )
                .Throws<ErrorApiException>();

            base.When();
        }
    }
}
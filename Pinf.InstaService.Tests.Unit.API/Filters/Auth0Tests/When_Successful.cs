using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;

namespace Pinf.InstaService.Tests.Unit.API.Filters.Auth0Tests
{
    public class When_Successful : Given_An_Auth0_Filter
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
                .Returns( Task.FromResult( new AccessTokenResponse { AccessToken = TestToken } ) );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Next_Middlware_Is_Executed( )
        {
            Assert.Null( MockActionExecutingContext.Result );
        }
    }
}
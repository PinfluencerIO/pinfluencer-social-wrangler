using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using NSubstitute;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.Auth0Tests
{
    public class When_Successful : Given_An_Auth0ActionFilter
    {
        protected override void When( )
        {
            base.When( );
            
            MockAuth0AuthenticationClient
                .GetToken( Arg.Any< ( string, string, string )>( ) )
                .Returns( TestToken );
            SUT.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Next_Middlware_Is_Executed( ) { Assert.Null( MockActionExecutingContext.Result ); }

        [ Test ]
        public void Then_Token_Is_Fetched_Once( ) { TokenWasFetchedOnce( ); }

        [ Test ]
        public void Then_Token_Is_Fetched_With_Valid_Body( ) { TokenWasFetchedWithValidBody( ); }

        [ Test ]
        public void Then_Management_Api_Client_Was_Set( )
        { 
            MockAuth0ManagementClientDecorator
                .Received( )
                .Secret = Arg.Any<string>( ); 
        }
    }
}
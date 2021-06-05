﻿using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests
{
    public class When_Auth0_Id_Is_Not_Found : When_Error_Occurs
    {
        protected override Dictionary<string, StringValues> SetupQueryParams( )
        {
            return new Dictionary<string, StringValues>( );
        }

        protected override Dictionary<string, object> SetupActionArguments( )
        {
            return new Dictionary<string, object>( );
        }

        protected override void When( )
        {
            base.When( );
            SetUpUserRepository( TestToken, OperationResultEnum.Success );
            SUT.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Error_Message_Is_Valid( )
        {
            Assert.AreEqual( "'auth-id' parameter was not present in the request", ErrorMessage );
        }

        [ Test ]
        public void Then_Instagram_Api_Is_Not_Called( )
        {
            MockTokenRepository
                .DidNotReceive( )
                .Get( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Graph_Api_Was_Not_Called( )
        {
            MockFacebookClient
                .DidNotReceive( )
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) );
        }
    }
}
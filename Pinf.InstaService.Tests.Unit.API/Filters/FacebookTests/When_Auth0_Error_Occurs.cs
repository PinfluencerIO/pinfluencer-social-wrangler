﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests
{
    public class When_Auth0_Error_Occurs : Given_A_FacebookActionFilter
    {
        protected override void When( )
        {
            base.When( );
            SetUpUserRepository( "", OperationResultEnum.Failed );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }
        
        [ Test ]
        public void Then_Error_Message_Is_Valid( ) { Assert.AreEqual( "auth0 id did not match an existing user", ErrorMessage ); }
        
        [ Test ]
        public void Then_Middlware_Short_Circuits( )
        {
            Assert.NotNull( MockActionExecutingContext.Result );
        }

        [ Test ]
        public void Then_Result_Status_Is_Unauthorized( )
        {
            Assert.True( MockActionExecutingContext.Result.GetType( ) == typeof( UnauthorizedObjectResult ) );
        }
        
        [ Test ]
        public void Then_User_Repository_Was_Fetched_From_Once( )
        {
            MockUserRepository
                .Received( 1 )
                .GetInstagramToken( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Valid_Auth0_Id_Was_Used( )
        {
            MockUserRepository
                .Received( )
                .GetInstagramToken( Arg.Is( TestAuth0Id ) );
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
using System;
using System.Collections.Generic;
using System.Net.Http;
using Auth0.AuthenticationApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Pinf.InstaService.Tests.Unit.API.Filters.Auth0Tests.Shared
{
    public abstract class When_Error_Occurs : Given_An_Auth0ActionFilter
    {
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
        public void Then_Management_Api_Client_Was_Not_Set( )
        {
            Assert.Null( MockAuth0Context.ManagementApiClient );
        }
    }
}
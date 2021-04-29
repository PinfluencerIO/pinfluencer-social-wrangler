﻿using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests.Shared
{
    public abstract class When_Error_Occurs : Given_A_FacebookActionFilter
    {
        [ Test ]
        public void Then_Middlware_Short_Circuits( ) { Assert.NotNull( MockActionExecutingContext.Result ); }

        [ Test ]
        public void Then_Result_Status_Is_Unauthorized( )
        {
            Assert.True( MockActionExecutingContext.Result.GetType( ) == typeof( UnauthorizedObjectResult ) );
        }
    }
}
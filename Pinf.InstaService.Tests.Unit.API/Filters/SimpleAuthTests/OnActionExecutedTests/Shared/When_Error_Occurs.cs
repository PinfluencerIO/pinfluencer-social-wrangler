﻿using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests.Shared
{
    public abstract class When_Error_Occurs : Given_A_Simple_Auth_Filter
    {
        protected string ErrorMessage => GetResultObject<UnauthorizedObjectResult, ErrorDto>( ).ErrorMsg;

        [ Test ]
        public void Then_Middlware_Short_Circuits( ) { Assert.NotNull( MockActionExecutedContext.Result ); }

        [ Test ]
        public void Then_Result_Status_Is_Unauthorized( )
        {
            Assert.True( MockActionExecutedContext.Result.GetType( ) == typeof( UnauthorizedObjectResult ) );
        }
    }
}
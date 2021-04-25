using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests.Shared
{
    public abstract class When_Error_Occurs : Given_A_SimpleAuthFilter
    {
        protected string ErrorMessage => GetResultObject<UnauthorizedObjectResult, ErrorDto>( ).ErrorMsg;

        [ Test ]
        public void Then_Middlware_Short_Circuits( ) { Assert.NotNull( MockActionExecutingContext.Result ); }

        [ Test ]
        public void Then_Result_Status_Is_Unauthorized( )
        {
            Assert.True( MockActionExecutingContext.Result.GetType( ) == typeof( UnauthorizedObjectResult ) );
        }
    }
}
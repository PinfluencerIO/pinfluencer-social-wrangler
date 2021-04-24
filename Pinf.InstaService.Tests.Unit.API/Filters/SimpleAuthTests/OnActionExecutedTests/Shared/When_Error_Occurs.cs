using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests.Shared
{
    public abstract class When_Error_Occurs : Given_A_Simple_Auth_Filter
    {
        [ Test ]
        public void Then_Middlware_Short_Circuits( )
        {
            Assert.NotNull( MockActionExecutedContext.Result );
        }

        [ Test ]
        public void Then_Result_Status_Is_Unauthorized( )
        {
            Assert.True( MockActionExecutedContext.Result.GetType( ) == typeof( UnauthorizedObjectResult ) );
        }
        
        protected string ErrorMessage => GetResultObject<UnauthorizedObjectResult, ErrorDto>( ).ErrorMsg;
    }
}
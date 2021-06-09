using System.Net;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.API.Core.Dtos.Response;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests.Shared
{
    public abstract class When_Error_Occurs : Given_A_SimpleAuthFilter
    {
        protected string ErrorMessage => GetResultObject<ErrorDto>( ).ErrorMsg;

        [ Test ]
        public void Then_Middlware_Short_Circuits( ) { Assert.NotNull( MockActionExecutingContext.Result ); }

        [ Test ]
        public void Then_Result_Status_Is_Unauthorized( )
        {
            Assert.AreEqual( HttpStatusCode.Unauthorized.GetHashCode( ),
                ( MockActionExecutingContext.Result as ContentResult ).StatusCode );
        }
    }
}
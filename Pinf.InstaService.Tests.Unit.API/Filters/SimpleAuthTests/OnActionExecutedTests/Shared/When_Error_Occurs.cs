using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests.Shared
{
    public abstract class When_Error_Occurs : Given_A_Simple_Auth_Filter
    {
        [ Test ]
        public void Then_Middlware_Short_Circuits( )
        {
            MockActionExecutedContext
                .DidNotReceive( )
                .Result = Arg.Any<IActionResult>( );
        }
    }
}
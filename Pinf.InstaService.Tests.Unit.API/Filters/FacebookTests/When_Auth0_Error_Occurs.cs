using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using Pinf.InstaService.BLL.Core.Enum;
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
    }
}
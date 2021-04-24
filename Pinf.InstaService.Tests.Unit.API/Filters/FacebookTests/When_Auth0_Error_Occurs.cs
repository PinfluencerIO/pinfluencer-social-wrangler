using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests
{
    public class When_Auth0_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            SetUpUserRepository( "", OperationResultEnum.Failed );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }
    }
}
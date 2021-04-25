using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests
{
    public class When_Auth0_Id_Is_Not_Found : When_Error_Occurs
    {
        protected override Dictionary<string, StringValues> SetupQueryParams( ) =>
            new Dictionary<string, StringValues>{ { Auth0IdParamKey, "" } };

        protected override void When( )
        {
            base.When( );
            SetUpUserRepository( TestToken, OperationResultEnum.Success );
            Sut.OnActionExecuting( MockActionExecutingContext );
        }
    }
}
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.Tests.Unit.API.FacebookMiddlware.Shared;

namespace Pinf.InstaService.Tests.Unit.API.FacebookMiddlware
{
    public class When_Auth0_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            SetAuth0Id( );

            TestToken = "";
            TokenFetchResult = OperationResultEnum.Failed;

            base.When( );
        }
    }
}
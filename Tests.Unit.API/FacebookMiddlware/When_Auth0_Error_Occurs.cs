using Bootstrapping.Services.Enum;
using Tests.Unit.API.FacebookMiddlware.Shared;

namespace Tests.Unit.API.FacebookMiddlware
{
    public class When_Auth0_Error_Occurs : When_Error_Occurs
    {
        protected override void When()
        {
            SetAuth0Id();

            TestToken = "";
            TokenFetchResult = OperationResultEnum.Failed;

            base.When();
        }
    }
}
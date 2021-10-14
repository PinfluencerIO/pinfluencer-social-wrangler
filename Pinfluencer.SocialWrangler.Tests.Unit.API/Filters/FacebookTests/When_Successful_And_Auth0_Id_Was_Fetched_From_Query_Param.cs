using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests
{
    public class When_Successful_And_Auth0_Id_Was_Fetched_From_Query_Param : When_Auth0_Communication_Was_Successful
    {
        protected override void When( )
        {
            base.When( );
            MockSocialAuthManager
                .Initialize( Arg.Any<string>( ) )
                .Returns( new Result { Status = OperationResultEnum.Success } );
            SUT.OnActionExecuting( MockActionExecutingContext );
        }

        [ Test ]
        public void Then_Next_Middlware_Is_Called( ) { Assert.Null( MockActionExecutingContext.Result ); }
    }
}
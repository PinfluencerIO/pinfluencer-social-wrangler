using Facebook;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.Tests.Unit.API.Middleware.FacebookMiddlware.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Middleware.FacebookMiddlware
{
    public class When_Token_Is_Invalid : When_Auth0_Error_Does_Not_Occur
    {
        protected override void When( )
        {
            SetAuth0Id( );

            TokenFetchResult = OperationResultEnum.Success;
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws<FacebookOAuthException>( );

            base.When( );
        }

        [ Test ]
        public void Then_Middlware_Short_Circuits( )
        {
            MockNextMiddlware
                .DidNotReceive( )
                .Invoke( Arg.Any<HttpContext>( ) );
        }

        [ Test ]
        public void Then_Response_Status_Code_Was_Not_Authorized( )
        {
            MockHttpResponse
                .Received( )
                .StatusCode = Arg.Is( 401 );
        }

        [ Test ]
        public void Then_Response_Status_Code_Was_Set_Once( )
        {
            MockHttpResponse
                .Received( 1 )
                .StatusCode = Arg.Any<int>( );
        }
    }
}
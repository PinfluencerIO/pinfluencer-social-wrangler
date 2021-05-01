using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.DAL.Common.Dtos;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get
{
    public class When_Facebook_Error_Occurs : When_Called
    {
        private OperationResult<IUser> _result;

        protected override void When( )
        {
            MockFacebookClient
                .Get<FacebookUser>( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( new FacebookOAuthException( "message" ) );
            _result = Sut.Get( "12345" );
        }

        [ Test ]
        public void Then_Empty_User_Is_Be_Returned( )
        {
            Assert.True( _result.Value.Id == null && _result.Value.Name == null );
        }

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }

        [ Test ]
        public void Then_Bubble_Profile_Will_Not_Be_Fetched( )
        {
            MockBubbleClient
                .DidNotReceive( )
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Error_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogError( Arg.Any<string>( ) );
        }
    }
}
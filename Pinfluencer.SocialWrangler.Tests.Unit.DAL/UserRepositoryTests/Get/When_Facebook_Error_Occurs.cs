using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get
{
    [ TestFixtureSource( nameof( FacebookExceptionFixture ) ) ]
    public class When_Facebook_Error_Occurs : When_Called
    {
        private readonly FacebookApiException _apiException;
        private OperationResult<User> _result;

        public When_Facebook_Error_Occurs( FacebookApiException apiException ) { _apiException = apiException; }
        
        protected override void When( )
        {
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( _apiException );
            _result = SUT.Get( "12345" );
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
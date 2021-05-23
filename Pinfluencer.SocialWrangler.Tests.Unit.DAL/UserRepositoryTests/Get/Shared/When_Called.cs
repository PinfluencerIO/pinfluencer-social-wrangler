using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Common.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get.Shared
{
    //TODO: REFACTOR INTEGRATION TESTS OUT, USE MOCKED BUBBLE DATA HANDLER
    public abstract class When_Called : Given_A_UserRepository
    {
        protected override void Given( )
        {
            base.Given( );
            MockBubbleDataHandler = new BubbleDataHandler<UserRepository>( MockBubbleClient, MockLogger );
            SUT = new UserRepository( Auth0Context, FacebookDecorator, MockLogger, MockBubbleDataHandler );
        }

        [ Test ]
        public void Then_Facebook_User_Will_Be_Fetched_Once( )
        {
            MockFacebookClient
                .Received( 1 )
                .Get( Arg.Any<string>( ), Arg.Any<object>( )  );
        }

        [ Test ]
        public void Then_Correct_Facebook_User_Endpoint_Is_Reached( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Is<string>( uri => uri == "me" ), Arg.Any<object>( )  );
        }

        [ Test ]
        public void Then_Correct_Facebook_User_Endpoint_Is_Passed_The_Correct_Fields( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Is<string>( uri => uri == "me" ), Arg.Is<RequestFields>( x => x.fields == "birthday,location,gender" )  );
        }
    }
}
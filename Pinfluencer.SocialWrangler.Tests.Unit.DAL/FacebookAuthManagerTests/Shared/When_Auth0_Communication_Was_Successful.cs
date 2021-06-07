using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookAuthManagerTests.Shared
{
    public abstract class When_Auth0_Communication_Was_Successful : Given_A_FacebookAuthManager
    {
        [ Test ]
        public void Then_Graph_Api_Was_Called_Once( )
        {
            MockFacebookDecorator
                .Received( 1 )
                .Get<object>( Arg.Any<string>( ), Arg.Any<object>( ) );
        }

        [ Test ]
        public void Then_User_Repository_Was_Fetched_From_Once( )
        {
            MockTokenRepository
                .Received( 1 )
                .Get( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Apis_Were_Fetched_In_The_Correct_Order( )
        {
            Received.InOrder( ( ) =>
            {
                MockTokenRepository
                    .Received( )
                    .Get( Arg.Is( TestAuth0Id ) );
                MockFacebookDecorator
                    .Received( )
                    .Get<object>( "debug_token", Arg.Is<RequestDebugTokenParams>( x => x.input_token.Equals( TestToken ) ) );
            } );
        }
    }
}
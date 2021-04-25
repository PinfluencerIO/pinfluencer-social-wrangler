using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.Tests.Unit.API.Filters.FacebookTests.Shared
{
    public abstract class When_Auth0_Communication_Was_Successful : Given_A_FacebookActionFilter
    {
        [ Test ]
        public void Then_Graph_Api_Was_Called_Once( )
        {
            MockFacebookClient
                .Received( 1 )
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) );
        }

        [ Test ]
        public void Then_User_Repository_Was_Fetched_From_Once( )
        {
            MockUserRepository
                .Received( 1 )
                .GetInstagramToken( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Apis_Were_Fetched_In_The_Correct_Order( )
        {
            Received.InOrder( ( ) =>
            {
                MockUserRepository
                    .Received( )
                    .GetInstagramToken( Arg.Is( TestAuth0Id ) );
                MockFacebookClient
                    .Received( )
                    .Get( "debug_token", Arg.Is<RequestDebugTokenParams>( x => x.input_token.Equals( TestToken ) ) );
            } );
        }
    }
}
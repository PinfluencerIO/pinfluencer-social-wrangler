using Auth0.Core.Exceptions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.Auth0AuthManagerTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Auth0AuthManagerTests
{
    public class When_Fetch_Token_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            base.When( );
            MockAuth0AuthenticationClient
                .GetToken( Arg.Any< ( string, string, string )>( ) )
                .Throws<ErrorApiException>( );
            Result = SUT.Initialize( );
        }

        [ Test ]
        public void Then_Token_Is_Fetched_Once( ) { TokenWasFetchedOnce( ); }

        [ Test ]
        public void Then_Token_Is_Fetched_With_Valid_Body( ) { TokenWasFetchedWithValidBody( ); }
    }
}
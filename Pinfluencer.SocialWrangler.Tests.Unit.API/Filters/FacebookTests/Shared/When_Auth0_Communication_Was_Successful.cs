using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.FacebookTests.Shared
{
    public abstract class When_Auth0_Communication_Was_Successful : Given_A_FacebookActionFilter
    {
        [ Test ]
        public void Then_Social_Was_Authenticated( )
        {
            MockSocialAuthManager
                .Received( 1 )
                .Initialize( Arg.Any<string>(  ) );
        }

        [ Test ]
        public void Then_Social_Was_Authenticated_With_Valid_User( )
        {
            MockSocialAuthManager
                .Received( )
                .Initialize( TestAuth0Id );
        }
    }
}
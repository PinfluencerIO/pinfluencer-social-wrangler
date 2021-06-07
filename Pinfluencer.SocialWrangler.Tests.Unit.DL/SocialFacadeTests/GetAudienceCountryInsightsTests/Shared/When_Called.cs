using NSubstitute;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetAudienceCountryInsightsTests.Shared
{
    public abstract class When_Called : Given_A_SocialFacade
    {
        protected const string InstagramId = "123";

        [ Test ]
        public void Then_Get_Country_Was_Called_Once( )
        {
            MockSocialAudienceCountryRepository
                .Received( 1 )
                .Get( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Get_Country_Was_Called_With_Correct_Instagram_Id( )
        {
            MockSocialAudienceCountryRepository
                .Received( 1 )
                .Get( InstagramId );
        }
    }
}
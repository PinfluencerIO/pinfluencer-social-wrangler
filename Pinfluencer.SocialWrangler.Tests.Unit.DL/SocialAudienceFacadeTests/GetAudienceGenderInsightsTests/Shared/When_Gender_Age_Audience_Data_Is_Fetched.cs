using NSubstitute;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialAudienceFacadeTests.GetAudienceGenderInsightsTests.Shared
{
    public abstract class When_Gender_Age_Audience_Data_Is_Fetched : Given_A_SocialAudienceFacade
    {
        protected const string InstagramId = "123";

        [ Test ]
        public void Then_Get_Gender_Age_Was_Called_Once( )
        {
            MockSocialAudienceGenderAgeRepository
                .Received( 1 )
                .Get( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Get_Gender_Age_Was_Called_With_Correct_Instagram_Id( )
        {
            MockSocialAudienceGenderAgeRepository
                .Received( 1 )
                .Get( InstagramId );
        }
    }
}
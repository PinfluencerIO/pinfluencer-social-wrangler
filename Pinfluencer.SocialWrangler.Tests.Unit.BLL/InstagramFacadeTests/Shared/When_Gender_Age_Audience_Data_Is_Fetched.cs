using NSubstitute;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.InstagramFacadeTests.Shared
{
    public abstract class When_Gender_Age_Audience_Data_Is_Fetched : Given_An_InstagramFacade
    {
        protected const string InstagramId = "123";

        [ Test ]
        public void Then_Get_Gender_Age_Was_Called_Once( )
        {
            MockSocialAudienceRepository
                .Received( 1 )
                .GetGenderAge( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Get_Gender_Age_Was_Called_With_Correct_Instagram_Id( )
        {
            MockSocialAudienceRepository
                .Received( 1 )
                .GetGenderAge( InstagramId );
        }
    }
}
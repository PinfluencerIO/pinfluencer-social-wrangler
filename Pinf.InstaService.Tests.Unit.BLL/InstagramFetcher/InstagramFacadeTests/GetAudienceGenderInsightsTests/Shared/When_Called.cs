using NSubstitute;
using NUnit.Framework;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetAudienceGenderInsightsTests.Shared
{
    public abstract class When_Called : Given_An_InstagramFacade
    {
        protected const string InstagramId = "123";
        
        [ Test ]
        public void Then_Get_Gender_Age_Was_Called_Once( )
        {
            MockInstaAudienceInsightsRepository
                .Received( 1 )
                .GetGenderAge( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Get_Gender_Age_Was_Called_With_Correct_Instagram_Id( )
        {
            MockInstaAudienceInsightsRepository
                .Received( 1 )
                .GetGenderAge( InstagramId );
        }
    }
}
using NSubstitute;
using NUnit.Framework;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.Shared
{
    public abstract class When_Gender_Age_Audience_Data_Is_Fetched : Given_An_InstagramFacade
    {
        protected const string InstagramId = "123";
        
        [ Test ]
        public void Then_Get_Gender_Age_Was_Called_Once( )
        {
            MockInstaAudienceRepository
                .Received( 1 )
                .GetGenderAge( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Get_Gender_Age_Was_Called_With_Correct_Instagram_Id( )
        {
            MockInstaAudienceRepository
                .Received( 1 )
                .GetGenderAge( InstagramId );
        }
    }
}
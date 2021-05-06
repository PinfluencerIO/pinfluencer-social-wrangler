using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InfluencerFacadeTests;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetAudienceCountryInsightsTests.Shared
{
    public abstract class When_Called : Given_An_InstagramFacade
    {
        protected const string InstagramId = "123";
        
        [ Test ]
        public void Then_Get_Country_Was_Called_Once( )
        {
            MockSocialAudienceRepository
                .Received( 1 )
                .GetCountry( Arg.Any<string>( ) );
        }
        
        [ Test ]
        public void Then_Get_Country_Was_Called_With_Correct_Instagram_Id( )
        {
            MockSocialAudienceRepository
                .Received( 1 )
                .GetCountry( InstagramId );
        }
    }
}
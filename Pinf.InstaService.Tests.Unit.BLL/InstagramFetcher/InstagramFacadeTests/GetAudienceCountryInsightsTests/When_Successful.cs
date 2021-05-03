using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetAudienceCountryInsightsTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetAudienceCountryInsightsTests
{
    public class When_Successful : When_Called
    {
        private OperationResult<IEnumerable<AudiencePercentage<RegionInfo>>> _result;

        protected override void When( )
        {
            MockInstaAudienceInsightsRepository
                .GetCountry( Arg.Any<string>(  ) )
                .Returns( new OperationResult<IEnumerable<FollowersInsight<RegionInfo>>>(
                    new [ ]
                    {
                        new FollowersInsight<RegionInfo>
                            { Count = 39, Property = RegionExtensions.GetRegion( CountryEnum.GB ) },
                        new FollowersInsight<RegionInfo>
                            { Count = 113, Property = RegionExtensions.GetRegion( CountryEnum.US ) },
                        new FollowersInsight<RegionInfo>
                            { Count = 113, Property = RegionExtensions.GetRegion( CountryEnum.FR ) }
                    },
                    OperationResultEnum.Success
                ) );
            _result = Sut.GetAudienceCountryInsights( InstagramId );
        }

        [ Test ]
        public void Then_Success_Is_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, _result.Status );
        }
        
        [ Test ]
        public void Then_Valid_FR_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.43, _result.Value.First( x => x.Value.Name == CountryEnum.FR.Stringify( ) ).Percentage );
        }
        
        [ Test ]
        public void Then_Valid_US_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.43, _result.Value.First( x => x.Value.Name == CountryEnum.US.Stringify( ) ).Percentage );
        }
        
        [ Test ]
        public void Then_Valid_GB_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.15, _result.Value.First( x => x.Value.Name == CountryEnum.GB.Stringify( ) ).Percentage );
        }
    }
}
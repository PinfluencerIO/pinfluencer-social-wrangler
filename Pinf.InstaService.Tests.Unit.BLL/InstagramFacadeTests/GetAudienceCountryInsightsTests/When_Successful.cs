using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFacadeTests.GetAudienceCountryInsightsTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFacadeTests.GetAudienceCountryInsightsTests
{
    public class When_Successful : When_Called
    {
        private OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>> _result;

        protected override void When( )
        {
            MockSocialAudienceRepository
                .GetCountry( Arg.Any<string>(  ) )
                .Returns( new OperationResult<IEnumerable<AudienceCount<LocationProperty>>>(
                    new [ ]
                    {
                        new AudienceCount<LocationProperty>
                            { Count = 39, Property = new LocationProperty{ Country = CountryGetter.Countries[ CountryEnum.GB ], CountryCode = CountryEnum.GB } },
                        new AudienceCount<LocationProperty>
                            { Count = 113, Property = new LocationProperty{ Country = CountryGetter.Countries[ CountryEnum.US ], CountryCode = CountryEnum.US } },
                        new AudienceCount<LocationProperty>
                            { Count = 113, Property = new LocationProperty{ Country = CountryGetter.Countries[ CountryEnum.FR ], CountryCode = CountryEnum.FR } }
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
            Assert.AreEqual( 0.43, _result.Value.First( x => x.Value.CountryCode == CountryEnum.FR ).Percentage );
        }
        
        [ Test ]
        public void Then_Valid_US_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.43, _result.Value.First( x => x.Value.CountryCode == CountryEnum.US ).Percentage );
        }
        
        [ Test ]
        public void Then_Valid_GB_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.15, _result.Value.First( x => x.Value.CountryCode == CountryEnum.GB ).Percentage );
        }
    }
}
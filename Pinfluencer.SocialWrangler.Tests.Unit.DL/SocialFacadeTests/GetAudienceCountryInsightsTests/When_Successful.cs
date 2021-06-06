using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetAudienceCountryInsightsTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetAudienceCountryInsightsTests
{
    public class When_Successful : When_Called
    {
        private ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>> _result;

        protected override void When( )
        {
            MockSocialAudienceCountryRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<AudienceCount<CountryProperty>>>(
                    new [ ]
                    {
                        new AudienceCount<CountryProperty>
                        {
                            Count = 39,
                            Property = new CountryProperty
                                { Country = CountryGetter.Countries[ CountryEnum.GB ], CountryCode = CountryEnum.GB }
                        },
                        new AudienceCount<CountryProperty>
                        {
                            Count = 113,
                            Property = new CountryProperty
                                { Country = CountryGetter.Countries[ CountryEnum.US ], CountryCode = CountryEnum.US }
                        },
                        new AudienceCount<CountryProperty>
                        {
                            Count = 113,
                            Property = new CountryProperty
                                { Country = CountryGetter.Countries[ CountryEnum.FR ], CountryCode = CountryEnum.FR }
                        }
                    },
                    OperationResultEnum.Success
                ) );
            _result = SUT.GetAudienceCountryInsights( InstagramId );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }

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
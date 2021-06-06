using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetAudienceGenderInsightsTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetAudienceAgeInsightsTests
{
    public class When_Successful : When_Gender_Age_Audience_Data_Is_Fetched
    {
        private ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>> _result;

        protected override void When( )
        {
            MockSocialAudienceGenderAgeRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<AudienceCount<GenderAgeProperty>>>(
                    new [ ]
                    {
                        new AudienceCount<GenderAgeProperty>
                        {
                            Count = 39,
                            Property = new GenderAgeProperty
                                { AgeRange = new Tuple<int, int?>( 18, 24 ), Gender = GenderEnum.Female }
                        },
                        new AudienceCount<GenderAgeProperty>
                        {
                            Count = 4,
                            Property = new GenderAgeProperty
                                { AgeRange = new Tuple<int, int?>( 25, 34 ), Gender = GenderEnum.Female }
                        },
                        new AudienceCount<GenderAgeProperty>
                        {
                            Count = 1,
                            Property = new GenderAgeProperty
                                { AgeRange = new Tuple<int, int?>( 45, 54 ), Gender = GenderEnum.Female }
                        },
                        new AudienceCount<GenderAgeProperty>
                        {
                            Count = 73,
                            Property = new GenderAgeProperty
                                { AgeRange = new Tuple<int, int?>( 18, 24 ), Gender = GenderEnum.Male }
                        },
                        new AudienceCount<GenderAgeProperty>
                        {
                            Count = 9,
                            Property = new GenderAgeProperty
                                { AgeRange = new Tuple<int, int?>( 25, 34 ), Gender = GenderEnum.Male }
                        },
                        new AudienceCount<GenderAgeProperty>
                        {
                            Count = 2,
                            Property = new GenderAgeProperty
                                { AgeRange = new Tuple<int, int?>( 35, 44 ), Gender = GenderEnum.Male }
                        },
                        new AudienceCount<GenderAgeProperty>
                        {
                            Count = 2,
                            Property = new GenderAgeProperty
                                { AgeRange = new Tuple<int, int?>( 45, 54 ), Gender = GenderEnum.Male }
                        },
                        new AudienceCount<GenderAgeProperty>
                        {
                            Count = 1,
                            Property = new GenderAgeProperty
                                { AgeRange = new Tuple<int, int?>( 55, 64 ), Gender = GenderEnum.Male }
                        }
                    },
                    OperationResultEnum.Success
                ) );
            _result = SUT.GetAudienceAgeInsights( "123" );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }

        [ Test ]
        public void Then_Valid_18_To_24_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.85, getAgeRangePercentage( _result.Value, 18, 24 ) );
        }

        [ Test ]
        public void Then_Valid_25_To_34_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.1, getAgeRangePercentage( _result.Value, 25, 34 ) );
        }

        [ Test ]
        public void Then_Valid_35_To_44_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.02, getAgeRangePercentage( _result.Value, 35, 44 ) );
        }

        [ Test ]
        public void Then_Valid_45_To_54_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.02, getAgeRangePercentage( _result.Value, 45, 54 ) );
        }

        [ Test ]
        public void Then_Valid_55_To_64_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.01, getAgeRangePercentage( _result.Value, 55, 64 ) );
        }

        private static double getAgeRangePercentage( IEnumerable<AudiencePercentage<AgeProperty>> collection, int lower,
            int higher )
        {
            return collection.First( x => x.Value.Min == lower && x.Value.Max == higher ).Percentage;
        }
    }
}
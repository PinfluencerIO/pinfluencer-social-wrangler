using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialAudienceFacadeTests.GetAudienceGenderInsightsTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialAudienceFacadeTests.GetAudienceGenderInsightsTests
{
    public class When_Successful : When_Gender_Age_Audience_Data_Is_Fetched
    {
        private ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>> _result;

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
            _result = SUT.GetAudienceGenderInsights( InstagramId );
        }

        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }

        [ Test ]
        public void Then_Valid_Female_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.34, _result.Value.First( x => x.Value == GenderEnum.Female ).Percentage );
        }

        [ Test ]
        public void Then_Valid_Male_Percentage_Is_Returned( )
        {
            Assert.AreEqual( 0.66, _result.Value.First( x => x.Value == GenderEnum.Male ).Percentage );
        }
    }
}
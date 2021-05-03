using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetAudienceGenderInsightsTests
{
    public class When_Successful : Given_An_InstagramFacade
    {
        private OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> _result;

        protected override void When( )
        {
            MockInstaAudienceInsightsRepository
                .GetGenderAge( Arg.Any<string>(  ) )
                .Returns( new OperationResult<IEnumerable<FollowersInsight<GenderAgeProperty>>>(
                    new [ ]
                    {
                        new FollowersInsight<GenderAgeProperty>
                            { Count = 39, Property = new GenderAgeProperty{ AgeRange = new Tuple<int, int?>( 18, 24 ), Gender = GenderEnum.Female } },
                        new FollowersInsight<GenderAgeProperty>
                            { Count = 4, Property = new GenderAgeProperty{ AgeRange = new Tuple<int, int?>( 25, 34 ), Gender = GenderEnum.Female } },
                        new FollowersInsight<GenderAgeProperty>
                            { Count = 1, Property = new GenderAgeProperty{ AgeRange = new Tuple<int, int?>( 45, 54 ), Gender = GenderEnum.Female } },
                        new FollowersInsight<GenderAgeProperty>
                            { Count = 73, Property = new GenderAgeProperty{ AgeRange = new Tuple<int, int?>( 18, 24 ), Gender = GenderEnum.Male } },
                        new FollowersInsight<GenderAgeProperty>
                            { Count = 9, Property = new GenderAgeProperty{ AgeRange = new Tuple<int, int?>( 25, 34 ), Gender = GenderEnum.Male } },
                        new FollowersInsight<GenderAgeProperty>
                            { Count = 2, Property = new GenderAgeProperty{ AgeRange = new Tuple<int, int?>( 35, 44 ), Gender = GenderEnum.Male } },
                        new FollowersInsight<GenderAgeProperty>
                            { Count = 2, Property = new GenderAgeProperty{ AgeRange = new Tuple<int, int?>( 45, 54 ), Gender = GenderEnum.Male } },
                        new FollowersInsight<GenderAgeProperty>
                            { Count = 1, Property = new GenderAgeProperty{ AgeRange = new Tuple<int, int?>( 55, 64 ), Gender = GenderEnum.Male } }
                    },
                    OperationResultEnum.Success
                ) );
            _result = Sut.GetAudienceGenderInsights( "123" );
        }

        [ Test ]
        public void Then_Success_Is_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, _result.Status );
        }
        
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
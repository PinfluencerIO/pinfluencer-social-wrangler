using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetAudienceGenderInsightsTests
{
    public class When_Unsuccessful : When_Gender_Age_Audience_Data_Is_Fetched
    {
        private OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> _result;

        protected override void When( )
        {
            MockInstaAudienceInsightsRepository
                .GetGenderAge( Arg.Any<string>( ) )
                .Returns( new OperationResult<IEnumerable<FollowersInsight<GenderAgeProperty>>>(
                    Enumerable.Empty<FollowersInsight<GenderAgeProperty>>(  ), 
                    OperationResultEnum.Failed
                ) );
            _result = Sut.GetAudienceGenderInsights( "123" );
        }

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }

        [ Test ]
        public void Then_Empty_Collection_Is_Returned( )
        {
            Assert.IsEmpty( _result.Value );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUserInsightsTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUserInsightsTests.
    ConstructedSuccessfullyTests
{
    public class When_Multiple_Insights_Are_Returned : When_Get_User_Insights_Is_Called
    {
        private OperationResult<IEnumerable<InstaProfileViewsInsight>> _result;

        protected override void When( )
        {
            ImpressionsColleciton = GetTwoImpressionsColleciton(
                new DateTime( 2000, 1, 1 ), 5,
                new DateTime( 2001, 2, 2 ), 10
            );
            ImpressionsOperationResult = OperationResultEnum.Success;

            base.When( );

            _result = Sut.GetUserInsights( TestId );
        }

        [ Test ]
        public void Then_Impressions_Count_Are_Correct( )
        {
            Assert.True( new [ ] { 5, 10 }.SequenceEqual( _result.Value.Select( x => x.Count ) ) );
        }

        [ Test ]
        public void Then_Impressions_Day_Is_Correct( )
        {
            Assert.True( new [ ] { 1, 2 }.SequenceEqual( _result.Value.Select( x => x.Time.Day ) ) );
        }

        [ Test ]
        public void Then_Impressions_Month_Is_Correct( )
        {
            Assert.True( new [ ] { 1, 2 }.SequenceEqual( _result.Value.Select( x => x.Time.Month ) ) );
        }

        [ Test ]
        public void Then_Impressions_Year_Is_Correct( )
        {
            Assert.True( new [ ] { 2000, 2001 }.SequenceEqual( _result.Value.Select( x => x.Time.Year ) ) );
        }

        [ Test ]
        public void Then_Result_Status_Is_Success( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
    }
}
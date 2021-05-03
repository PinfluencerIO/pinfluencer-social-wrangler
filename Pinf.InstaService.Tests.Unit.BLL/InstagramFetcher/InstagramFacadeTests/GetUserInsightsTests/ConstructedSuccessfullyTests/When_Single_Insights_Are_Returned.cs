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
    [ TestFixture ]
    public class When_Single_Insights_Are_Returned : When_Get_User_Insights_Is_Called
    {
        private OperationResult<IEnumerable<ProfileViewsInsight>> _result;

        protected override void When( )
        {
            ImpressionsColleciton = GetSingleImpressionsColleciton( new DateTime( 2000, 1, 1 ), 5 );
            ImpressionsOperationResult = OperationResultEnum.Success;

            base.When( );

            _result = Sut.GetMonthlyProfileViews( TestId );
        }

        [ Test ]
        public void Then_Impressions_Count_Are_Correct( )
        {
            Assert.AreEqual( 5, _result.Value.First( ).Count );
        }

        [ Test ]
        public void Then_Impressions_Day_Is_Correct( )
        {
            Assert.AreEqual( 1, _result.Value.First( ).Time.Day );
        }

        [ Test ]
        public void Then_Impressions_Month_Is_Correct( )
        {
            Assert.AreEqual( 1, _result.Value.First( ).Time.Month );
        }

        [ Test ]
        public void Then_Impressions_Year_Is_Correct( )
        {
            Assert.AreEqual( 2000, _result.Value.First( ).Time.Year );
        }

        [ Test ]
        public void Then_Result_Status_Is_Success( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
    }
}
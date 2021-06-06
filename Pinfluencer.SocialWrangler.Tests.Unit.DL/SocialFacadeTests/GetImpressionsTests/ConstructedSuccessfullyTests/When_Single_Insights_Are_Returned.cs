using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetImpressionsTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetImpressionsTests.
    ConstructedSuccessfullyTests
{
    [ TestFixture ]
    public class When_Single_Insights_Are_Returned : When_Called
    {
        private ObjectResult<IEnumerable<ContentImpressions>> _result;

        protected override void When( )
        {
            ImpressionsColleciton = GetSingleImpressionsColleciton( new DateTime( 2000, 1, 1 ), 5 );
            ImpressionsOperationResult = OperationResultEnum.Success;

            base.When( );

            _result = SUT.GetMonthlyProfileViews( TestId );
        }

        [ Test ]
        public void Then_Impressions_Count_Are_Correct( ) { Assert.AreEqual( 5, _result.Value.First( ).Count ); }

        [ Test ]
        public void Then_Impressions_Day_Is_Correct( ) { Assert.AreEqual( 1, _result.Value.First( ).Time.Day ); }

        [ Test ]
        public void Then_Impressions_Month_Is_Correct( ) { Assert.AreEqual( 1, _result.Value.First( ).Time.Month ); }

        [ Test ]
        public void Then_Impressions_Year_Is_Correct( ) { Assert.AreEqual( 2000, _result.Value.First( ).Time.Year ); }

        [ Test ]
        public void Then_Result_Status_Is_Success( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
    }
}
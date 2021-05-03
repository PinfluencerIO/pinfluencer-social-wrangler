using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUserInsightsTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUserInsightsTests.
    FailTests
{
    public class When_Insights_Fails_To_Be_Returned : When_Get_User_Insights_Is_Called
    {
        private OperationResult<IEnumerable<ProfileViewsInsight>> _result;

        protected override void When( )
        {
            ImpressionsOperationResult = OperationResultEnum.Failed;

            ImpressionsColleciton = Enumerable.Empty<ProfileViewsInsight>( );

            base.When( );

            _result = Sut.GetMonthlyProfileViews( TestId );
        }

        [ Test ]
        public void Then_Empty_Impressions_Are_Returned( ) { Assert.IsEmpty( _result.Value ); }

        [ Test ]
        public void Then_Return_Status_Is_Fail( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }
    }
}
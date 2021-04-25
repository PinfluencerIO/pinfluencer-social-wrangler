using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.BLL.Models.Insights;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstagramFacadeTests.GetUserInsightsTests.Shared
{
    public abstract class When_Get_User_Insights_Is_Called : Given_An_InstagramFacade
    {
        protected const string TestId = "";

        protected OperationResultEnum ImpressionsOperationResult { get; set; }
        protected IEnumerable<InstaImpression> ImpressionsColleciton { get; set; }

        protected override void When( )
        {
            MockImpressionsInsightsRepository
                .GetImpressions( Arg.Any<string>( ) )
                .Returns(
                    new OperationResult<IEnumerable<InstaImpression>>(
                        ImpressionsColleciton, ImpressionsOperationResult
                    )
                );
        }

        [ Test ]
        public void Then_Get_Impressions_Insights_Was_Called_Once( )
        {
            MockImpressionsInsightsRepository
                .Received( 1 )
                .GetImpressions( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Get_Impressions_Insights_Was_Called_With_Correct_Id( )
        {
            MockImpressionsInsightsRepository
                .Received( )
                .GetImpressions( Arg.Is( TestId ) );
        }

        protected IEnumerable<InstaImpression> GetSingleImpressionsColleciton( DateTime date, int impressions )
        {
            return new [ ]
            {
                new InstaImpression( date, impressions )
            };
        }

        protected IEnumerable<InstaImpression> GetTwoImpressionsColleciton(
            DateTime date1,
            int impressions1,
            DateTime date2,
            int impressions2
        )
        {
            return new [ ]
            {
                new InstaImpression( date1, impressions1 ),
                new InstaImpression( date2, impressions2 )
            };
        }

        protected void SetDefaultImpressionsColleciton( )
        {
            ImpressionsColleciton = GetSingleImpressionsColleciton( new DateTime( 2000, 1, 1 ), 5 );
            ImpressionsOperationResult = OperationResultEnum.Success;
        }
    }
}
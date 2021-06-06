using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InstagramFacadeTests.GetImpressionsTests.Shared
{
    public abstract class When_Called : Given_An_InstagramFacade
    {
        protected const string TestId = "";

        protected OperationResultEnum ImpressionsOperationResult { get; set; }
        protected IEnumerable<ContentImpressions> ImpressionsColleciton { get; set; }

        protected override void When( )
        {
            ImpressionsInsightsRepository
                .Get( Arg.Any< string >( ),
                    Arg.Any< PeriodEnum >( ),
                    Arg.Any< (DateTime start, DateTime end) >( ) )
                .Returns(
                    new ObjectResult<IEnumerable<ContentImpressions>>(
                        ImpressionsColleciton, ImpressionsOperationResult
                    )
                );
        }

        [ Test ]
        public void Then_Get_Impressions_Insights_Was_Called_Once( )
        {
            ImpressionsInsightsRepository
                .Received( 1 )
                .Get( Arg.Any< string >( ),
                    Arg.Any< PeriodEnum >( ),
                    Arg.Any< (DateTime start, DateTime end) >( ) );
        }

        [ Test ]
        public void Then_Correct_Users_Impressions_Were_Fetched_From_Last_28_Days( )
        {
            ImpressionsInsightsRepository
                .Received( )
                .Get( Arg.Is( TestId ),
                    PeriodEnum.Day28,
                    ( CurrentTime, CurrentTime.AddDays( 1 ) ) );
        }

        protected IEnumerable<ContentImpressions> GetSingleImpressionsColleciton( DateTime date, int impressions )
        {
            return new [ ]
            {
                new ContentImpressions( date, impressions )
            };
        }

        protected IEnumerable<ContentImpressions> GetTwoImpressionsColleciton(
            DateTime date1,
            int impressions1,
            DateTime date2,
            int impressions2
        )
        {
            return new [ ]
            {
                new ContentImpressions( date1, impressions1 ),
                new ContentImpressions( date2, impressions2 )
            };
        }
    }
}
using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.InstagramFacadeTests.GetProfileViewsTests.Shared
{
    public abstract class When_Get_User_Insights_Is_Called : Given_An_InstagramFacade
    {
        protected const string TestId = "";

        protected OperationResultEnum ImpressionsOperationResult { get; set; }
        protected IEnumerable<ContentImpressions> ImpressionsColleciton { get; set; }

        protected override void When( )
        {
            ImpressionsInsightsRepository
                .Get( Arg.Any<string>( ) )
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
                .Get( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Get_Impressions_Insights_Was_Called_With_Correct_Id( )
        {
            ImpressionsInsightsRepository
                .Received( )
                .Get( Arg.Is( TestId ) );
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

        protected void SetDefaultImpressionsColleciton( )
        {
            ImpressionsColleciton = GetSingleImpressionsColleciton( new DateTime( 2000, 1, 1 ), 5 );
            ImpressionsOperationResult = OperationResultEnum.Success;
        }
    }
}
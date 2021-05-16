using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaImpressionsRepository.GetImpressionsTests.Shared
{
    public abstract class When_Called : Given_A_InstaImpressionsRepository
    {
        protected const string TestId = "123456789";

        [ Test ]
        public void Then_Correct_Url_Was_Hit( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Is( $"{TestId}/insights" ), Arg.Any<object>( ) );
        }

        [ Test ]
        public void Then_Correct_Metric_Query_Params_Were_Used( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Any<string>( ), Arg.Is<RequestInsightParams>(
                    x =>
                        x.metric == "impressions" &&
                        x.period == "day" &&
                        x.since == 1607650400 &&
                        x.until == 1610150400
                ) );
        }

        [ Test ]
        public void Then_Get_Impressions_Was_Called_Once( )
        {
            MockFacebookClient
                .Received( 1 )
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) );
        }
    }
}
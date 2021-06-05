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
            MockFacebookDecorator
                .Received( )
                .Get<DataArray<Metric<int>>>( Arg.Is( $"{TestId}/insights" ), Arg.Any<object>( ) );
        }

        [ Test ]
        public void Then_Correct_Metric_Query_Params_Were_Used( )
        {
            MockFacebookDecorator
                .Received( )
                .Get<DataArray<Metric<int>>>( Arg.Any<string>( ), Arg.Is<RequestInsightParams>(
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
            MockFacebookDecorator
                .Received( 1 )
                .Get<DataArray<Metric<int>>>( Arg.Any<string>( ), Arg.Any<object>( ) );
        }
    }
}
using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramInsightsDataHandlerTests.Get
{
    [ TestFixture( "reach" ) ]
    [ TestFixture( "impressions" ) ]
    public class When_Metric_Varies : Given_An_InstagramInsightsDataHandler
        {
        private readonly string _metric;

        private ObjectResult<IEnumerable<SocialInsightsBase>> _result;

        public When_Metric_Varies( string metric ) { _metric = metric; }

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<SocialInsightsBase>>>( ),
                    Arg.Any<IEnumerable<SocialInsightsBase>>( ),
                    Arg.Any<RequestInsightParams>( ) )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsBase>>( SocialInsightsBase,
                    OperationResultEnum.Success ) );
            _result = SUT.Read( "123",
                PeriodEnum.Day28,
                ( new DateTime( 2021, 5, 28 ),
                    new DateTime( 2021, 5, 29 ) ),
                _metric );
        }
        
        [ Test ]
        public void Then_Valid_Metric_Was_Used( )
        {
            MockFacebookDataHandler
                .Received( )
                .Read( Arg.Any<string>(  ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<SocialInsightsBase>>>( ),
                    Arg.Any<IEnumerable<SocialInsightsBase>>( ),
                    Arg.Is<RequestInsightParams>( x => x.metric == _metric ) );
        }
    }
}
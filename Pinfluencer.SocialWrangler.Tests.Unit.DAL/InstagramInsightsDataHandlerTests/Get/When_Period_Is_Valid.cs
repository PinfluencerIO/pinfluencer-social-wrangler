using System;
using System.Collections.Generic;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramInsightsDataHandlerTests.Get
{
    [ TestFixture( PeriodEnum.Day, "day" ) ]
    [ TestFixture( PeriodEnum.Day28, "days_28" ) ]
    [ TestFixture( PeriodEnum.Week, "week" ) ]
    public class When_Period_Is_Valid : Given_An_InstagramInsightsDataHandler
    {
        private readonly PeriodEnum _periodEnum;
        private readonly string _period;

        private ObjectResult<IEnumerable<SocialInsightsBase>> _result;

        public When_Period_Is_Valid( PeriodEnum periodEnum, string period )
        {
            _periodEnum = periodEnum;
            _period = period;
        }

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<SocialInsightsBase>>>( ),
                    Arg.Any<IEnumerable<SocialInsightsBase>>( ),
                    Arg.Any<RequestInsightParams>( ) )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsBase>>( SocialInsightsBase,
                    OperationResultEnum.Success ) );
            _result = SUT.Read( "123", _periodEnum, ( new DateTime( 2021, 5, 28 ), new DateTime( 2021, 5, 29 ) ),
                "reach" );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<SocialInsightsBase>>>( ),
                    Arg.Any<IEnumerable<SocialInsightsBase>>( ),
                    Arg.Is<RequestInsightParams>( x => x.period == _period ) );
        }
    }
}
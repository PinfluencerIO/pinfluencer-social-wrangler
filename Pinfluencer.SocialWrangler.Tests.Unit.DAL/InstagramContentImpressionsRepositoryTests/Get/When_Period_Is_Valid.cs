using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentImpressionsRepositoryTests.Get
{
    [ TestFixture( PeriodEnum.Day, "day" ) ]
    [ TestFixture( PeriodEnum.Day28, "days_28" ) ]
    [ TestFixture( PeriodEnum.Week, "week" ) ]
    public class When_Period_Is_Valid : Given_An_InstagramContentImpressionsRepository
    {
        private readonly PeriodEnum _periodEnum;
        private readonly string _period;

        private OperationResult<IEnumerable<ContentImpressions>> _result;

        public When_Period_Is_Valid( PeriodEnum periodEnum, string period )
        {
            _periodEnum = periodEnum;
            _period = period;
        }

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>,IEnumerable<ContentImpressions>>>( ),
                    Arg.Any<IEnumerable<ContentImpressions>>( ),
                    Arg.Any<RequestInsightParams>( ) )
                .Returns( new OperationResult<IEnumerable<ContentImpressions>>( When_Called.DefaultContentImpressions,
                    OperationResultEnum.Success ) );
            _result = SUT.Get( "123", _periodEnum, ( new DateTime( 2021, 5, 28 ), new DateTime( 2021, 5, 29 ) ) );
        }
        
        [ Test ]
        public void Then_Valid_Call_Was_Made( ) =>
            MockFacebookDataHandler
                .Received( )
                .Read( Arg.Any<string>(  ),
                    Arg.Any<Func<DataArray<Metric<int>>,IEnumerable<ContentImpressions>>>(  ),
                    Arg.Any<IEnumerable<ContentImpressions>>( ),
                    Arg.Is<RequestInsightParams>( x => x.period == _period ) );
    }
}
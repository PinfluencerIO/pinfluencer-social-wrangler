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
    [ TestFixture( PeriodEnum.Lifetime ) ]
    [ TestFixture( PeriodEnum.Month ) ]
    public class When_Period_Is_Invalid : Given_An_InstagramInsightsDataHandler
    {
        private readonly PeriodEnum _periodEnum;

        private ObjectResult<IEnumerable<SocialInsightsBase>> _result;

        public When_Period_Is_Invalid( PeriodEnum periodEnum ) { _periodEnum = periodEnum; }

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
                _periodEnum,
                ( new DateTime( 2021, 5, 28 ),
                    new DateTime( 2021, 5, 29 ) ),
                "reach" );
        }

        [ Test ]
        public void Then_Call_Was_Not_Made( )
        {
            MockFacebookDataHandler
                .DidNotReceive( )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<SocialInsightsBase>>>( ),
                    Arg.Any<IEnumerable<SocialInsightsBase>>( ),
                    Arg.Any<RequestInsightParams>( ) );
        }

        [ Test ]
        public void Then_Failiure_Was_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }
    }
}
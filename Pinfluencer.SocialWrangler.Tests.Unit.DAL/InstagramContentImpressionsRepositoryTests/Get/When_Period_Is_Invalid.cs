using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentImpressionsRepositoryTests.Get
{
    [ TestFixture( PeriodEnum.Lifetime ) ]
    [ TestFixture( PeriodEnum.Month ) ]
    public class When_Period_Is_Invalid : Given_An_InstagramContentImpressionsRepository
    {
        private readonly PeriodEnum _periodEnum;

        private OperationResult<IEnumerable<ContentImpressions>> _result;

        public When_Period_Is_Invalid( PeriodEnum periodEnum )
        {
            _periodEnum = periodEnum;
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
        
        [ Test ] public void Then_Call_Was_Not_Made( ) =>
            MockFacebookDataHandler
                .DidNotReceive( )
                .Read( Arg.Any<string>(  ),
                    Arg.Any<Func<DataArray<Metric<int>>,IEnumerable<ContentImpressions>>>(  ),
                    Arg.Any<IEnumerable<ContentImpressions>>( ),
                    Arg.Any<RequestInsightParams>( ) );

        [ Test ] public void Then_Failiure_Was_Returned( ) =>
            Assert.AreEqual( OperationResultEnum.Failed, _result.Status );
    }
}
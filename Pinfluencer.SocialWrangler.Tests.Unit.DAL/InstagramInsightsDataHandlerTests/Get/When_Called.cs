using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramInsightsDataHandlerTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_InstagramInsightsDataHandler
    {
        private ObjectResult<IEnumerable<SocialInsightsBase>> _result;
        private readonly ObjectResult<IEnumerable<SocialInsightsBase>> _objectResult;

        public When_Called( IEnumerable<SocialInsightsBase> audienceCountries, OperationResultEnum operationResultEnum )
        {
            _objectResult =
                new ObjectResult<IEnumerable<SocialInsightsBase>>( audienceCountries,
                    operationResultEnum );
        }

        private static readonly object [ ] data =
        {
            new object [ ]
            {
                SocialInsightsBase,
                OperationResultEnum.Success
            },
            new object [ ]
            {
                Enumerable.Empty<SocialInsightsBase>( ),
                OperationResultEnum.Failed
            }
        };

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<SocialInsightsBase>>>( ),
                    Arg.Any<IEnumerable<SocialInsightsBase>>( ),
                    Arg.Any<RequestInsightParams>( ) )
                .Returns( _objectResult );
            _result = SUT.Read( "123",
                PeriodEnum.Day,
                ( new DateTime( 2021, 5, 28 ),
                    new DateTime( 2021, 5, 29 ) ),
                "reach" );
        }

        [ Test ]
        public void Then_Get_Insights_Is_Called_Once( )
        {
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<SocialInsightsBase>>>( ),
                    Arg.Any<IEnumerable<SocialInsightsBase>>( ),
                    Arg.Any<RequestInsightParams>( ) );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( )
                .Read<IEnumerable<SocialInsightsBase>, DataArray<Metric<int>>>( "123/insights",
                    SUT.MapMany,
                    Arg.Is<IEnumerable<SocialInsightsBase>>( x => !x.Any( ) ),
                    Arg.Is<RequestInsightParams>( x => x.period == "day"
                                                       && x.since == 1622160000
                                                       && x.until == 1622246400 ) );
        }

        [ Test ]
        public void Then_Valid_Response_Was_Returned( ) { Assert.AreSame( _objectResult, _result ); }
    }
}
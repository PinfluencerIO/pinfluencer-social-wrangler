using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentImpressionsRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_InstagramContentImpressionsRepository
    {
        private ObjectResult<IEnumerable<ContentImpressions>> _result;
        private readonly ObjectResult<IEnumerable<ContentImpressions>> _objectResult;

        public static readonly IEnumerable<ContentImpressions> DefaultContentImpressions = new [ ]
        {
            new ContentImpressions
            {
                Count = 6,
                Time = new DateTime( 2021, 11, 26 )
            },
            new ContentImpressions
            {
                Count = 54,
                Time = new DateTime( 2021, 11, 26 )
            },
            new ContentImpressions
            {
                Count = 65,
                Time = new DateTime( 2021, 11, 26 )
            }
        };

        public When_Called( IEnumerable<ContentImpressions> audienceCountries, OperationResultEnum operationResultEnum )
        {
            _objectResult =
                new ObjectResult<IEnumerable<ContentImpressions>>( audienceCountries,
                    operationResultEnum );
        }

        private static readonly object [ ] data =
        {
            new object [ ]
            {
                DefaultContentImpressions,
                OperationResultEnum.Success
            },
            new object [ ]
            {
                Enumerable.Empty<ContentImpressions>( ),
                OperationResultEnum.Failed
            }
        };

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<ContentImpressions>>>( ),
                    Arg.Any<IEnumerable<ContentImpressions>>( ),
                    Arg.Any<RequestInsightParams>( ) )
                .Returns( _objectResult );
            _result = SUT.Get( "123", PeriodEnum.Day, ( new DateTime( 2021, 5, 28 ), new DateTime( 2021, 5, 29 ) ) );
        }

        [ Test ]
        public void Then_Get_Audience_Gender_Age_Is_Called_Once( )
        {
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<ContentImpressions>>>( ),
                    Arg.Any<IEnumerable<ContentImpressions>>( ),
                    Arg.Any<RequestInsightParams>( ) );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( )
                .Read<IEnumerable<ContentImpressions>, DataArray<Metric<int>>>( "123/insights",
                    SUT.MapMany,
                    Arg.Is<IEnumerable<ContentImpressions>>( x => !x.Any( ) ),
                    Arg.Is<RequestInsightParams>( x => x.metric == "impressions"
                                                       && x.period == "day"
                                                       && x.since == 1622160000
                                                       && x.until == 1622246400 ) );
        }

        [ Test ]
        public void Then_Valid_Response_Was_Returned( ) { Assert.AreSame( _objectResult, _result ); }
    }
}
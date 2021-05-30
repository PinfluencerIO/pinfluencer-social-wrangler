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
        private OperationResult<IEnumerable<ContentImpressions>> _result;
        private OperationResult<IEnumerable<ContentImpressions>> _operationResult;


        public When_Called( IEnumerable<ContentImpressions> audienceCountries, OperationResultEnum operationResultEnum )
        {
            _operationResult =
                new OperationResult<IEnumerable<ContentImpressions>>( audienceCountries,
                    operationResultEnum );
        }

        private static readonly object [ ] data =
        {
            new object [ ]
            {
                new [ ]
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
                },
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
                .Returns( _operationResult );
            _result = SUT.Get( "123", PeriodEnum.Day, ( CurrentTime, CurrentTime.Add( new TimeSpan( 1,0, 0, 0 ) ) ) );
        }

        [ Test ]
        public void Then_Get_Audience_Gender_Age_Is_Called_Once( ) =>
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>, IEnumerable<ContentImpressions>>>( ),
                    Arg.Any<IEnumerable<ContentImpressions>>( ),
                    Arg.Any<RequestInsightParams>( ) );

        [ Test ]
        public void Then_Valid_Call_Was_Made( ) =>
            MockFacebookDataHandler
                .Received( )
                .Read<IEnumerable<ContentImpressions>, DataArray<Metric<int>>>( "123/insights",
                    SUT.MapMany,
                    Arg.Is<IEnumerable<ContentImpressions>>( x => !x.Any( ) ),
                    Arg.Is<RequestInsightParams>( x => x.metric == "impressions"
                                                       && x.period == "day"
                                                       && x.since == 1622156400
                                                       && x.until == 1622242800 ) );

        [ Test ]
        public void Then_Valid_Response_Was_Returned( ) { Assert.AreSame( _operationResult, _result ); }
    }
}
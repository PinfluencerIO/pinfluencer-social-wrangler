using System;
using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentReachRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_InstagramContentReachRepository
    {
        private ObjectResult<IEnumerable<ContentReach>> _result;
        private readonly ObjectResult<IEnumerable<ContentReach>> _objectResult;

        public static readonly IEnumerable<ContentReach> DefaultContentReach = new [ ]
        {
            new ContentReach
            {
                Count = 6,
                Time = new DateTime( 2021, 11, 26 )
            },
            new ContentReach
            {
                Count = 54,
                Time = new DateTime( 2021, 11, 26 )
            },
            new ContentReach
            {
                Count = 65,
                Time = new DateTime( 2021, 11, 26 )
            }
        };

        public When_Called( IEnumerable<ContentReach> audienceCountries, OperationResultEnum operationResultEnum )
        {
            _objectResult =
                new ObjectResult<IEnumerable<ContentReach>>( audienceCountries,
                    operationResultEnum );
        }

        private static readonly object [ ] data =
        {
            new object [ ]
            {
                DefaultContentReach,
                OperationResultEnum.Success
            },
            new object [ ]
            {
                Enumerable.Empty<ContentReach>( ),
                OperationResultEnum.Failed
            }
        };

        protected override void When( )
        {
            MockInstagramInsightsDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<PeriodEnum>( ),
                    Arg.Any<( DateTime, DateTime )>( ),
                    Arg.Any<string>( ) )
                .Returns( _objectResult );
            _result = SUT.Get( "123", PeriodEnum.Day28, ( new DateTime( 2021, 5, 28 ), new DateTime( 2021, 5, 29 ) ) );
        }

        [ Test ]
        public void Then_Get_Audience_Gender_Age_Is_Called_Once( )
        {
            MockInstagramInsightsDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<PeriodEnum>( ),
                    Arg.Any<( DateTime, DateTime )>( ),
                    Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockInstagramInsightsDataHandler
                .Received( 1 )
                .Read( "123",
                    PeriodEnum.Day28,
                    Arg.Is<( DateTime start, DateTime end )>( x =>
                        x.start.ToString( "MM/dd/yyyy" ) == "05/28/2021" &&
                        x.end.ToString( "MM/dd/yyyy" ) == "05/29/2021"),
                    "reach" );
        }

        [ Test ]
        public void Then_Valid_Response_Was_Returned( ) { Assert.AreSame( _objectResult, _result ); }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialFacadeTests.GetReach
{
    [ TestFixtureSource( nameof( _data ) ) ]
    public class When_Called : Given_A_SocialFacade
    {

        private static object [ ] _data =
        {
            new object [ ]
            {
                new []
                {
                    new ContentReach
                    {
                        Time = new DateTime( 2021, 12, 2 ),
                        Count = 5
                    }
                },
                OperationResultEnum.Success
            },
            new object [ ]
            {
                Enumerable.Empty<ContentReach>(  ),
                OperationResultEnum.Failed
            }
        };

        private ObjectResult<IEnumerable<ContentReach>> _result;
        private ObjectResult<IEnumerable<ContentReach>> _operationResult;

        public When_Called( IEnumerable<ContentReach> contentReachArray, OperationResultEnum operationResult )
        {
            _operationResult = new ObjectResult<IEnumerable<ContentReach>>
            {
                Status = operationResult,
                Value = contentReachArray
            };
        }
        
        protected override void When( )
        {
            MockSocialContentReachRepository
                .Get( Arg.Any<string>( ), Arg.Any<PeriodEnum>( ), Arg.Any<(DateTime start, DateTime end)>( ) )
                .Returns( _operationResult );
            _result = SUT.GetReach( "123" );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockSocialContentReachRepository
                .Received( 1 )
                .Get( Arg.Any<string>( ),
                    Arg.Any<PeriodEnum>( ),
                    Arg.Any<(DateTime start, DateTime end)>( ) );
            MockSocialContentReachRepository
                .Received( )
                .Get( "123",
                    PeriodEnum.Day28,
                    ( CurrentTime.Subtract( new TimeSpan( 1, 0, 0, 0 ) ), CurrentTime ) );
        }

        [ Test ]
        public void Then_Valid_Result_Was_Returned( )
        {
            Assert.AreSame( _operationResult, _result );
        }
    }
}
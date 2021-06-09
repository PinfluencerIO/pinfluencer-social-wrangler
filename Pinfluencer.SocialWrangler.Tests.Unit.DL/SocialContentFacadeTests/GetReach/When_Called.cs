using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetReach
{
    [ TestFixtureSource( nameof( _data ) ) ]
    public class When_Called : Given_A_SocialContentFacade
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
                OperationResultEnum.Success,
                5
            },
            new object [ ]
            {
                Enumerable.Empty<ContentReach>(  ),
                OperationResultEnum.Failed,
                0
            }
        };
        
        private readonly int _expectedReach;
        private ObjectResult<int> _result;
        private readonly ObjectResult<IEnumerable<ContentReach>> _operationResult;

        public When_Called( IEnumerable<ContentReach> contentReachArray,
            OperationResultEnum operationResult,
            int expectedReach )
        {
            _expectedReach = expectedReach;
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
        public void Then_Valid_Object_Was_Returned( )
        {
            Assert.AreEqual( _operationResult.Status, _result.Status );
            Assert.AreEqual( _expectedReach, _result.Value );
        }
    }
}
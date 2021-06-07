using System;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramEngagementRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_InstagramEngagementRepository
    {
        private readonly int _content;
        private readonly OperationResultEnum _status;

        private static object [ ] data =
        {
            new object[]
            {
                43,
                OperationResultEnum.Failed
            },
            new object[]
            {
                120,
                OperationResultEnum.Success
            }
        };

        private ObjectResult<int> _result;

        public When_Called( int content, OperationResultEnum status )
        {
            _content = content;
            _status = status;
        }

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>,int>>( ),
                    Arg.Any<int>( ),
                    Arg.Any<RequestInsightParams>( ) )
                .Returns( new ObjectResult<int>
                {
                    Status = _status,
                    Value = _content
                } );
            _result = SUT.Get( "123" );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<int>>,int>>( ),
                    Arg.Any<int>( ),
                    Arg.Any<RequestInsightParams>( ) );
            MockFacebookDataHandler
                .Received( )
                .Read<int,DataArray<Metric<int>>>( "123/insights",
                    SUT.MapOut,
                    default,
                    Arg.Is<RequestInsightParams>( x => x.metric == "engagement" ) );
        }
        
        [ Test ]
        public void Then_Valid_Status_Was_Returned( )
        {
            Assert.AreEqual( _status, _result.Status );
        }
    }
}
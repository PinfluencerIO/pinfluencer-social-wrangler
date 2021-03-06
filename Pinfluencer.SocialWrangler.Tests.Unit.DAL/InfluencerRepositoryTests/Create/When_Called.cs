using System;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InfluencerRepositoryTests.Create
{
    [ TestFixture( OperationResultEnum.Success ) ]
    [ TestFixture( OperationResultEnum.Failed ) ]
    public class When_Called : Given_A_InfluencerRepository
    {
        private readonly OperationResultEnum _operationResult;
        private OperationResultEnum _result;

        public When_Called( OperationResultEnum operationResult ) { _operationResult = operationResult; }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Create( Arg.Any<string>( ), Arg.Any<InfluencerModel>( ),
                    Arg.Any<Func<InfluencerModel, Influencer>>( ) )
                .Returns( _operationResult );
            _result = SUT.Create( DefaultInfluencer );
        }

        [ Test ]
        public void Then_Create_Was_Called_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Create( Arg.Any<string>( ), Arg.Any<InfluencerModel>( ),
                    Arg.Any<Func<InfluencerModel, Influencer>>( ) );
        }

        [ Test ]
        public void Then_Correct_Resource_Was_Uses( )
        {
            MockBubbleDataHandler
                .Received( )
                .Create( Arg.Is( "influencer" ),
                    Arg.Is<InfluencerModel>( x =>
                        x.Age == DefaultInfluencer.Age &&
                        x.Bio == DefaultInfluencer.Bio &&
                        x.Gender == DefaultInfluencer.Gender &&
                        x.Location.Country == DefaultInfluencer.Location.Country &&
                        x.Location.City == DefaultInfluencer.Location.City &&
                        x.User.Id == DefaultInfluencer.User.Id &&
                        x.SocialUsername == DefaultInfluencer.SocialUsername ),
                    SUT.MapIn );
        }

        [ Test ]
        public void Then_Valid_Status_Was_Returned( ) { Assert.AreEqual( _operationResult, _result ); }
    }
}
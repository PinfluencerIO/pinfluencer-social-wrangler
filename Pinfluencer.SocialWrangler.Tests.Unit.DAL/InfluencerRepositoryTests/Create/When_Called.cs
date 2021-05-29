using System;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Influencer = Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble.Influencer;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InfluencerRepositoryTests.Create
{
    [ TestFixture( OperationResultEnum.Success ) ]
    [ TestFixture( OperationResultEnum.Failed ) ]
    public class When_Called : Given_A_InfluencerRepository
    {
        private readonly OperationResultEnum _operationResult;
        private OperationResultEnum _result;

        private InfluencerModel DefaultInfluencer
        {
            get
            {
                
                SocialInfoUser.Id = "12345678";
                return new InfluencerModel
                {
                    InstagramHandle = "example",
                    Age = 24,
                    Bio = "this an example bio",
                    Gender = GenderEnum.Male,
                    Location = "Uxbridge, West London",
                    User = new User{ Id = "12345678" }
                };
            }
        }

        public When_Called( OperationResultEnum operationResult ) { _operationResult = operationResult; }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Create( Arg.Any<string>( ), Arg.Any<InfluencerModel>( ), Arg.Any<Func<InfluencerModel,Influencer>>( ) )
                .Returns( _operationResult );
            _result = SUT.Create( DefaultInfluencer );
        }

        [ Test ]
        public void Then_Create_Was_Called_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Create( Arg.Any<string>( ), Arg.Any<InfluencerModel>( ), Arg.Any<Func<InfluencerModel, Influencer>>( ) );
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
                        x.Location == DefaultInfluencer.Location &&
                        x.User.Id == DefaultInfluencer.User.Id &&
                        x.InstagramHandle == DefaultInfluencer.InstagramHandle ),
                        SUT.MapIn );
        }

        [ Test ]
        public void Then_Valid_Influencer_Is_Created( )
        {
            var mapResult = SUT.MapIn( DefaultInfluencer );
            Assert.True( mapResult.Age == DefaultInfluencer.Age &&
                         mapResult.Bio == DefaultInfluencer.Bio &&
                         mapResult.Gender == DefaultInfluencer.Gender &&
                         mapResult.Instagram == DefaultInfluencer.InstagramHandle &&
                         mapResult.Location == DefaultInfluencer.Location &&
                         mapResult.Profile == DefaultInfluencer.User.Id );
        }

        [ Test ]
        public void Then_Valid_Status_Was_Returned( ) { Assert.AreEqual( _operationResult, _result ); }
    }
}
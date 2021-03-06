using System;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceAgeRepositoryTests.Create
{
    [ TestFixture( OperationResultEnum.Success ) ]
    [ TestFixture( OperationResultEnum.Failed ) ]
    public class When_Called : Given_An_AudienceAgeRepository
    {
        private readonly OperationResultEnum _operationResult;
        private OperationResultEnum _result;

        private const string AgeString = "13-17";

        private AudiencePercentage<AgeProperty> DefaultAudienceAge =>
            new AudiencePercentage<AgeProperty>
            {
                Audience = new AudienceModel { Id = "123" },
                Id = "2",
                Percentage = 0.6,
                Value = new AgeProperty { Max = 17, Min = 13 }
            };

        public When_Called( OperationResultEnum operationResult ) { _operationResult = operationResult; }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Create( Arg.Any<string>( ), Arg.Any<AudiencePercentage<AgeProperty>>( ),
                    Arg.Any<Func<AudiencePercentage<AgeProperty>, AudienceAge>>( ) )
                .Returns( _operationResult );
            _result = SUT.Create( DefaultAudienceAge );
        }

        [ Test ]
        public void Then_Create_Was_Called_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Create( Arg.Any<string>( ), Arg.Any<AudiencePercentage<AgeProperty>>( ),
                    Arg.Any<Func<AudiencePercentage<AgeProperty>, AudienceAge>>( ) );
        }

        [ Test ]
        public void Then_Correct_Resource_Was_Uses( )
        {
            MockBubbleDataHandler
                .Received( )
                .Create( Arg.Is( "audienceage" ), Arg.Any<AudiencePercentage<AgeProperty>>( ),
                    Arg.Any<Func<AudiencePercentage<AgeProperty>, AudienceAge>>( ) );
        }

        [ Test ]
        public void Then_Model_Was_Passed_In( )
        {
            MockBubbleDataHandler
                .Received( )
                .Create( Arg.Any<string>( ), Arg.Is<AudiencePercentage<AgeProperty>>( x =>
                        x.Audience.Id == DefaultAudienceAge.Audience.Id &&
                        x.Id == DefaultAudienceAge.Id &&
                        x.Percentage.Equals( DefaultAudienceAge.Percentage ) &&
                        x.Value.Min == DefaultAudienceAge.Value.Min &&
                        x.Value.Max == DefaultAudienceAge.Value.Max ),
                    Arg.Any<Func<AudiencePercentage<AgeProperty>, AudienceAge>>( ) );
        }

        [ Test ]
        public void Then_Valid_Influencer_Is_Created( )
        {
            var mapResult = SUT.ModelMap( DefaultAudienceAge );
            Assert.True( mapResult.Audience == DefaultAudienceAge.Audience.Id &&
                         mapResult.Id == DefaultAudienceAge.Id &&
                         mapResult.Range == AgeString &&
                         mapResult.Percentage.Equals( DefaultAudienceAge.Percentage ) );
        }

        [ Test ]
        public void Then_Valid_Status_Was_Returned( ) { Assert.AreEqual( _operationResult, _result ); }
    }
}
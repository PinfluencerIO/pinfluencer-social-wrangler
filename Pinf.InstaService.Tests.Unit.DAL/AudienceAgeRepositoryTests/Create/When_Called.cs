using System;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceAgeRepositoryTests.Create
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
                Value = new AgeProperty{ Max = 17, Min = 13 }
            };

        public When_Called( OperationResultEnum operationResult ) { _operationResult = operationResult; }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Create( Arg.Any<string>( ), Arg.Any<AudiencePercentage<AgeProperty>>( ), Arg.Any<Func<AudiencePercentage<AgeProperty>,AudienceAge>>( ) )
                .Returns( _operationResult );
            _result = Sut.Create( DefaultAudienceAge );
        }

        [ Test ]
        public void Then_Create_Was_Called_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Create( Arg.Any<string>( ), Arg.Any<AudiencePercentage<AgeProperty>>( ), Arg.Any<Func<AudiencePercentage<AgeProperty>, AudienceAge>>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Resource_Was_Uses( )
        {
            MockBubbleDataHandler
                .Received( )
                .Create( Arg.Is( "audienceage" ), Arg.Any<AudiencePercentage<AgeProperty>>( ), Arg.Any<Func<AudiencePercentage<AgeProperty>, AudienceAge>>( ) );
        }
        
        [ Test ]
        public void Then_Model_Was_Passed_In( )
        {
            MockBubbleDataHandler
                .Received( )
                .Create( Arg.Any<string>( ), Arg.Is<AudiencePercentage<AgeProperty>>( x => x.Audience.Id == DefaultAudienceAge.Audience.Id &&
                                                                           x.Id == DefaultAudienceAge.Id &&
                                                                           x.Percentage.Equals( DefaultAudienceAge.Percentage ) &&
                                                                           x.Value == DefaultAudienceAge.Value ), 
                    Arg.Any<Func<AudiencePercentage<AgeProperty>, AudienceAge>>( ) );
        }
        
        [ Test ]
        public void Then_Valid_Influencer_Is_Created( )
        {
            var mapResult = Sut.ModelMap( DefaultAudienceAge );
            Assert.True( mapResult.Audience == DefaultAudienceAge.Audience.Id &&
                         mapResult.Id == DefaultAudienceAge.Id &&
                         mapResult.Range == AgeString &&
                         mapResult.Percentage.Equals( DefaultAudienceAge.Percentage ) );
        }

        [ Test ]
        public void Then_Valid_Status_Was_Returned( ) { Assert.AreEqual( _operationResult, _result ); }
    }
}
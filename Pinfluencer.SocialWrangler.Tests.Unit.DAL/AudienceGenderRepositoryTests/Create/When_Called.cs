using System;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceGenderRepositoryTests.Create
{
    [ TestFixture( OperationResultEnum.Success ) ]
    [ TestFixture( OperationResultEnum.Failed ) ]
    public class When_Called : Given_An_AudienceGenderRepository
    {
        private readonly OperationResultEnum _operationResult;
        private OperationResultEnum _result;

        private AudiencePercentage<GenderEnum> DefaultAudienceGender =>
            new AudiencePercentage<GenderEnum>
            {
                Audience = new AudienceModel { Id = "123" },
                Id = "2",
                Percentage = 0.6,
                Value = GenderEnum.Male
            };

        public When_Called( OperationResultEnum operationResult ) { _operationResult = operationResult; }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Create( Arg.Any<string>( ), Arg.Any<AudiencePercentage<GenderEnum>>( ), Arg.Any<Func<AudiencePercentage<GenderEnum>,AudienceGender>>( ) )
                .Returns( _operationResult );
            _result = SUT.Create( DefaultAudienceGender );
        }

        [ Test ]
        public void Then_Create_Was_Called_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Create( Arg.Any<string>( ), Arg.Any<AudiencePercentage<GenderEnum>>( ), Arg.Any<Func<AudiencePercentage<GenderEnum>, AudienceGender>>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Resource_Was_Uses( )
        {
            MockBubbleDataHandler
                .Received( )
                .Create( Arg.Is( "audiencegender" ), Arg.Any<AudiencePercentage<GenderEnum>>( ), Arg.Any<Func<AudiencePercentage<GenderEnum>, AudienceGender>>( ) );
        }
        
        [ Test ]
        public void Then_Model_Was_Passed_In( )
        {
            MockBubbleDataHandler
                .Received( )
                .Create( Arg.Any<string>( ), Arg.Is<AudiencePercentage<GenderEnum>>( x => x.Audience.Id == DefaultAudienceGender.Audience.Id &&
                                                                           x.Id == DefaultAudienceGender.Id &&
                                                                           x.Percentage.Equals( DefaultAudienceGender.Percentage ) &&
                                                                           x.Value == DefaultAudienceGender.Value ), 
                    Arg.Any<Func<AudiencePercentage<GenderEnum>, AudienceGender>>( ) );
        }
        
        [ Test ]
        public void Then_Valid_Influencer_Is_Created( )
        {
            var mapResult = SUT.ModelMap( DefaultAudienceGender );
            Assert.True( mapResult.Audience == DefaultAudienceGender.Audience.Id &&
                         mapResult.Id == DefaultAudienceGender.Id &&
                         mapResult.Name == DefaultAudienceGender.Value.ToString( ) &&
                         mapResult.Percentage.Equals( DefaultAudienceGender.Percentage ) );
        }

        [ Test ]
        public void Then_Valid_Status_Was_Returned( ) { Assert.AreEqual( _operationResult, _result ); }
    }
}
using System;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceLocationRepositoryTests.Create
{
    [ TestFixture( OperationResultEnum.Success ) ]
    [ TestFixture( OperationResultEnum.Failed ) ]
    public class When_Called : Given_An_AudienceLocationRepository
    {
        private readonly OperationResultEnum _operationResult;
        private OperationResultEnum _result;

        private AudiencePercentage<LocationProperty> DefaultAudienceLocation =>
            new AudiencePercentage<LocationProperty>
            {
                Audience = new AudienceModel { Id = "123" },
                Id = "2",
                Percentage = 0.6,
                Value = new LocationProperty{ Country = "United States", CountryCode = CountryEnum.US }
            };

        public When_Called( OperationResultEnum operationResult ) { _operationResult = operationResult; }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Create( Arg.Any<string>( ), Arg.Any<AudiencePercentage<LocationProperty>>( ), Arg.Any<Func<AudiencePercentage<LocationProperty>,AudienceLocation>>( ) )
                .Returns( _operationResult );
            _result = SUT.Create( DefaultAudienceLocation );
        }

        [ Test ]
        public void Then_Create_Was_Called_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Create( Arg.Any<string>( ), Arg.Any<AudiencePercentage<LocationProperty>>( ), Arg.Any<Func<AudiencePercentage<LocationProperty>, AudienceLocation>>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Resource_Was_Uses( )
        {
            MockBubbleDataHandler
                .Received( )
                .Create( Arg.Is( "audiencelocation" ), Arg.Any<AudiencePercentage<LocationProperty>>( ), Arg.Any<Func<AudiencePercentage<LocationProperty>, AudienceLocation>>( ) );
        }
        
        [ Test ]
        public void Then_Model_Was_Passed_In( )
        {
            MockBubbleDataHandler
                .Received( )
                .Create( Arg.Any<string>( ), Arg.Is<AudiencePercentage<LocationProperty>>( x => x.Audience.Id == DefaultAudienceLocation.Audience.Id &&
                                                                           x.Id == DefaultAudienceLocation.Id &&
                                                                           x.Percentage.Equals( DefaultAudienceLocation.Percentage ) &&
                                                                           x.Value.Country == DefaultAudienceLocation.Value.Country &&
                                                                           x.Value.CountryCode == DefaultAudienceLocation.Value.CountryCode ), 
                    Arg.Any<Func<AudiencePercentage<LocationProperty>, AudienceLocation>>( ) );
        }
        
        [ Test ]
        public void Then_Valid_Influencer_Is_Created( )
        {
            var mapResult = SUT.ModelMap( DefaultAudienceLocation );
            Assert.True( mapResult.Audience == DefaultAudienceLocation.Audience.Id &&
                         mapResult.Id == DefaultAudienceLocation.Id &&
                         mapResult.Place == "" &&
                         mapResult.Percentage.Equals( DefaultAudienceLocation.Percentage ) );
        }

        [ Test ]
        public void Then_Valid_Status_Was_Returned( ) { Assert.AreEqual( _operationResult, _result ); }
    }
}
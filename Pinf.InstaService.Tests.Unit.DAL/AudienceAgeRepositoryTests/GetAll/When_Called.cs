using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceAgeRepositoryTests.GetAll
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_AudienceAgeRepository
    {
        private readonly IEnumerable<AudiencePercentage<AgeProperty>> _audienceAge;
        private readonly OperationResultEnum _operationResult;
        private OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>> _result;

        private static object [ ] data = {
            new object [ ]
            {
                new [ ]
                {
                    new AudiencePercentage<AgeProperty>
                    {
                        Audience = new AudienceModel { Id = "123" }, Id = "1", Value = new AgeProperty{ Min = 13, Max = 17 },
                        Percentage = 0.75
                    },
                    new AudiencePercentage<AgeProperty>
                    {
                        Audience = new AudienceModel { Id = "123" }, Id = "2", Value = new AgeProperty{ Min = 18, Max = 24 },
                        Percentage = 0.25
                    }
                },
                OperationResultEnum.Success
            },
            new object[ ]
            {
                Enumerable.Empty<AudiencePercentage<AgeProperty>>( ),
                OperationResultEnum.Failed
            }
        };

        public When_Called( IEnumerable<AudiencePercentage<AgeProperty>> audienceAge, OperationResultEnum operationResult )
        {
            _audienceAge = audienceAge;
            _operationResult = operationResult;
        }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<TypeResponse<BubbleCollection<AudienceAge>>, IEnumerable<AudiencePercentage<AgeProperty>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<AgeProperty>>>( ) )
                .Returns( new OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>>( _audienceAge, _operationResult ) );
            _result = Sut.GetAll( "123" );
        }
        
        [ Test ]
        public void Then_Data_Is_Read_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ), Arg.Any<Func<TypeResponse<BubbleCollection<AudienceAge>>, IEnumerable<AudiencePercentage<AgeProperty>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<AgeProperty>>>( ) );
        }

        [ Test ]
        public void Then_Correct_Resource_Is_Used( )
        {
            MockBubbleDataHandler
                .Received( )
                .Read( Arg.Is( "audienceage" ), Arg.Any<Func<TypeResponse<BubbleCollection<AudienceAge>>, IEnumerable<AudiencePercentage<AgeProperty>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<AgeProperty>>>( ) );
        }

        [ Test ]
        public void Then_Correct_Status_Is_Returned( )
        {
            Assert.AreEqual( _operationResult, _result.Status );
        }
        
        [ Test ]
        public void Then_Correct_Model_Is_Returned( )
        {
            Assert.AreSame( _audienceAge, _result.Value );
        }
    }
}
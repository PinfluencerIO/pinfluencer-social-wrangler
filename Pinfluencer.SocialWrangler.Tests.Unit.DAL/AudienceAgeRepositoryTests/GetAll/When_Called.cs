using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceAgeRepositoryTests.GetAll
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_AudienceAgeRepository
    {
        private readonly IEnumerable<AudiencePercentage<AgeProperty>> _audienceAge;
        private readonly TypeResponse<BubbleCollection<AudienceAge>> _audienceAgeRaw;
        private readonly OperationResultEnum _operationResult;
        private ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>> _result;

        private static object [ ] data =
        {
            new object [ ]
            {
                new [ ]
                {
                    new AudiencePercentage<AgeProperty>
                    {
                        Audience = new AudienceModel { Id = "123" }, Id = "1",
                        Value = new AgeProperty { Min = 13, Max = 17 },
                        Percentage = 0.75
                    },
                    new AudiencePercentage<AgeProperty>
                    {
                        Audience = new AudienceModel { Id = "123" }, Id = "2",
                        Value = new AgeProperty { Min = 18, Max = 24 },
                        Percentage = 0.25
                    }
                },
                new TypeResponse<BubbleCollection<AudienceAge>>
                {
                    Type = new BubbleCollection<AudienceAge>
                    {
                        Results = new [ ]
                        {
                            new AudienceAge
                            {
                                Audience = "123",
                                Id = "1",
                                Range = "13-17",
                                Percentage = 0.75
                            },
                            new AudienceAge
                            {
                                Audience = "123",
                                Id = "2",
                                Range = "18-24",
                                Percentage = 0.25
                            }
                        }
                    }
                },
                OperationResultEnum.Success
            },
            new object [ ]
            {
                Enumerable.Empty<AudiencePercentage<AgeProperty>>( ),
                new TypeResponse<BubbleCollection<AudienceAge>>
                    { Type = new BubbleCollection<AudienceAge> { Results = Enumerable.Empty<AudienceAge>( ) } },
                OperationResultEnum.Failed
            }
        };

        public When_Called( IEnumerable<AudiencePercentage<AgeProperty>> audienceAge,
            TypeResponse<BubbleCollection<AudienceAge>> audienceAgeRaw, OperationResultEnum operationResult )
        {
            _audienceAge = audienceAge;
            _audienceAgeRaw = audienceAgeRaw;
            _operationResult = operationResult;
        }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<TypeResponse<BubbleCollection<AudienceAge>>,
                        IEnumerable<AudiencePercentage<AgeProperty>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<AgeProperty>>>( ) )
                .Returns( new ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>>( _audienceAge,
                    _operationResult ) );
            _result = SUT.GetAll( "123" );
        }

        [ Test ]
        public void Then_Data_Is_Read_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<TypeResponse<BubbleCollection<AudienceAge>>,
                        IEnumerable<AudiencePercentage<AgeProperty>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<AgeProperty>>>( ) );
        }

        [ Test ]
        public void Then_Correct_Resource_Is_Used( )
        {
            MockBubbleDataHandler
                .Received( )
                .Read( Arg.Is( "audienceage" ),
                    Arg.Any<Func<TypeResponse<BubbleCollection<AudienceAge>>,
                        IEnumerable<AudiencePercentage<AgeProperty>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<AgeProperty>>>( ) );
        }

        [ Test ]
        public void Then_Mapping_Is_Correct( )
        {
            var mapResult = SUT.DataMap( _audienceAgeRaw );
            Assert.True( mapResult.Select( x => x.Id ).SequenceEqual( _audienceAge.Select( x => x.Id ) ) &&
                         mapResult.Select( x => x.Percentage )
                             .SequenceEqual( _audienceAge.Select( x => x.Percentage ) ) &&
                         mapResult.Select( x => x.Value.Max )
                             .SequenceEqual( _audienceAge.Select( x => x.Value.Max ) ) &&
                         mapResult.Select( x => x.Value.Min )
                             .SequenceEqual( _audienceAge.Select( x => x.Value.Min ) ) &&
                         mapResult.Select( x => x.Audience.Id )
                             .SequenceEqual( _audienceAge.Select( x => x.Audience.Id ) ) );
        }

        [ Test ]
        public void Then_Correct_Status_Is_Returned( ) { Assert.AreEqual( _operationResult, _result.Status ); }

        [ Test ]
        public void Then_Correct_Model_Is_Returned( ) { Assert.AreSame( _audienceAge, _result.Value ); }
    }
}
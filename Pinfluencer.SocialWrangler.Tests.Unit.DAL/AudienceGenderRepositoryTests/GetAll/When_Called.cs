using System;
using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceGenderRepositoryTests.GetAll
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_AudienceGenderRepository
    {
        private readonly IEnumerable<AudiencePercentage<GenderEnum>> _audienceGender;
        private readonly TypeResponse<BubbleCollection<AudienceGender>> _audienceGenderRaw;
        private readonly OperationResultEnum _operationResult;
        private ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>> _result;

        private static object [ ] data =
        {
            new object [ ]
            {
                new [ ]
                {
                    new AudiencePercentage<GenderEnum>
                    {
                        Audience = new AudienceModel { Id = "123" }, Id = "1", Value = GenderEnum.Male,
                        Percentage = 0.75
                    },
                    new AudiencePercentage<GenderEnum>
                    {
                        Audience = new AudienceModel { Id = "123" }, Id = "2", Value = GenderEnum.Female,
                        Percentage = 0.25
                    }
                },
                new TypeResponse<BubbleCollection<AudienceGender>>
                {
                    Type = new BubbleCollection<AudienceGender>
                    {
                        Results = new [ ]
                        {
                            new AudienceGender
                            {
                                Audience = "123",
                                Id = "1",
                                Name = "Male",
                                Percentage = 0.75
                            },
                            new AudienceGender
                            {
                                Audience = "123",
                                Id = "2",
                                Name = "Female",
                                Percentage = 0.25
                            }
                        }
                    }
                },
                OperationResultEnum.Success
            },
            new object [ ]
            {
                Enumerable.Empty<AudiencePercentage<GenderEnum>>( ),
                new TypeResponse<BubbleCollection<AudienceGender>>
                {
                    Type = new BubbleCollection<AudienceGender> { Results = Enumerable.Empty<AudienceGender>( ) }
                },
                OperationResultEnum.Failed
            }
        };

        public When_Called( IEnumerable<AudiencePercentage<GenderEnum>> audienceGender,
            TypeResponse<BubbleCollection<AudienceGender>> audienceGenderRaw,
            OperationResultEnum operationResult )
        {
            _audienceGender = audienceGender;
            _audienceGenderRaw = audienceGenderRaw;
            _operationResult = operationResult;
        }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<TypeResponse<BubbleCollection<AudienceGender>>,
                        IEnumerable<AudiencePercentage<GenderEnum>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<GenderEnum>>>( ) )
                .Returns( new ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>>( _audienceGender,
                    _operationResult ) );
            _result = SUT.GetAll( "123" );
        }

        [ Test ]
        public void Then_Data_Is_Read_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<TypeResponse<BubbleCollection<AudienceGender>>,
                        IEnumerable<AudiencePercentage<GenderEnum>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<GenderEnum>>>( ) );
        }

        [ Test ]
        public void Then_Correct_Resource_Is_Used( )
        {
            MockBubbleDataHandler
                .Received( )
                .Read( Arg.Is( "audiencegender" ),
                    Arg.Any<Func<TypeResponse<BubbleCollection<AudienceGender>>,
                        IEnumerable<AudiencePercentage<GenderEnum>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<GenderEnum>>>( ) );
        }

        [ Test ]
        public void Then_Mapping_Is_Correct( )
        {
            var mapResult = SUT.DataMap( _audienceGenderRaw );
            Assert.True( mapResult.Select( x => x.Id ).SequenceEqual( _audienceGender.Select( x => x.Id ) ) &&
                         mapResult.Select( x => x.Percentage )
                             .SequenceEqual( _audienceGender.Select( x => x.Percentage ) ) &&
                         mapResult.Select( x => x.Value ).SequenceEqual( _audienceGender.Select( x => x.Value ) ) &&
                         mapResult.Select( x => x.Audience.Id )
                             .SequenceEqual( _audienceGender.Select( x => x.Audience.Id ) ) );
        }

        [ Test ]
        public void Then_Correct_Status_Is_Returned( ) { Assert.AreEqual( _operationResult, _result.Status ); }

        [ Test ]
        public void Then_Correct_Model_Is_Returned( ) { Assert.AreSame( _audienceGender, _result.Value ); }
    }
}
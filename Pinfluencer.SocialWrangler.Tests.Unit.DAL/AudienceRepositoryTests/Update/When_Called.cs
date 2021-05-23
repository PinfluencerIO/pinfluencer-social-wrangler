using System;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceRepositoryTests.Update
{
    [ TestFixture( OperationResultEnum.Success ) ]
    [ TestFixture( OperationResultEnum.Failed ) ]
    public class When_Called : Given_An_AudienceRepository
    {
        private readonly OperationResultEnum _operationResult;
        private OperationResultEnum _result;
        
        protected AudienceModel DefaultAudience => new AudienceModel {
                AudienceAge = new [ ]
                {
                    new AudiencePercentage<AgeProperty>
                    {
                        Percentage = 0.5, Value = new AgeProperty
                        {
                            Max = 24,
                            Min = 18
                        }
                    },
                    new AudiencePercentage<AgeProperty>
                    {
                        Percentage = 0.25, Value = new AgeProperty
                        {
                            Max = 34,
                            Min = 25
                        }
                    },
                    new AudiencePercentage<AgeProperty>
                    {
                        Percentage = 0.25, Value = new AgeProperty
                        {
                            Max = null,
                            Min = 65
                        }
                    }
                },
                AudienceGender = new [ ]
                {
                    new AudiencePercentage<GenderEnum>
                    {
                        Percentage = 0.75, Value = GenderEnum.Female
                    },
                    new AudiencePercentage<GenderEnum>
                    {
                        Percentage = 0.25, Value = GenderEnum.Male
                    }
                },
                AudienceLocation = new [ ]
                {
                    new AudiencePercentage<LocationProperty>
                    {
                        Percentage = 0.5, Value = new LocationProperty
                        {
                            Country = "United Kingdom"
                        }
                    },
                    new AudiencePercentage<LocationProperty>
                    {
                        Percentage = 0.25, Value = new LocationProperty
                        {
                            Country = "United States"
                        }
                    },
                    new AudiencePercentage<LocationProperty>
                    {
                        Percentage = 0.25, Value = new LocationProperty
                        {
                            Country = "Spain"
                        }
                    }
                }
            };

        public When_Called( OperationResultEnum operationResult ) { _operationResult = operationResult; }
        
        protected override void When( )
        {
            MockBubbleDataHandler
                .Update( Arg.Any<string>( ), Arg.Any<AudienceModel>( ), Arg.Any<Func<AudienceModel, Audience>>( ) )
                .Returns( _operationResult );
            _result = SUT.Update( DefaultAudience );
        }

        [ Test ]
        public void Then_Update_Was_Called_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Update( Arg.Any<string>( ), Arg.Any<AudienceModel>( ), Arg.Any<Func<AudienceModel, Audience>>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Model_Was_Passed_In( )
        {
            MockBubbleDataHandler
                .Received( )
                .Update( Arg.Any<string>( ), Arg.Is<AudienceModel>( x => x.Id == DefaultAudience.Id &&
                                                                         x.AudienceAge.Select( x => x.Id ).SequenceEqual( DefaultAudience.AudienceAge.Select( x => x.Id ) ) &&
                                                                         x.AudienceGender.Select( x => x.Id ).SequenceEqual( DefaultAudience.AudienceGender.Select( x => x.Id ) ) &&
                                                                         x.AudienceLocation.Select( x => x.Id ).SequenceEqual( DefaultAudience.AudienceLocation.Select( x => x.Id ) ) ),
                    Arg.Any<Func<AudienceModel, Audience>>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Audience_Was_Created( )
        {
            var mapResult = SUT.ModelMap( DefaultAudience );
            Assert.True( mapResult.AudienceAge.SequenceEqual( DefaultAudience.AudienceAge.Select( x => x.Id ) ) &&
                         mapResult.AudienceGender.SequenceEqual( DefaultAudience.AudienceGender.Select( x => x.Id ) ) &&
                         mapResult.AudienceLocation.SequenceEqual( DefaultAudience.AudienceLocation.Select( x => x.Id ) ) );
        }
        
        [ Test ]
        public void Then_Correct_Resource_Is_Used( )
        {
            MockBubbleDataHandler
                .Received( )
                .Update( Arg.Is( "audience" ), Arg.Any<AudienceModel>( ), Arg.Any<Func<AudienceModel, Audience>>( ) );
        }
        
        [ Test ]
        public void Then_Valid_Status_Is_Returned( ) { Assert.AreEqual( _operationResult, _result ); }
    }
}
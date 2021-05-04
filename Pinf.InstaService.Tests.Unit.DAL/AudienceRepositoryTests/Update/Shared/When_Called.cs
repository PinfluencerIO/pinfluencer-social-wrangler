using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests.Update.Shared
{
    public abstract class When_Called : Given_An_AudienceRepository
    {
        protected Core.Models.Audience DefaultAudience =>
            new Core.Models.Audience
            {
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
        
        [ Test ]
        public void Then_Audience_Will_Be_Updated_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Patch( Arg.Any<string>( ), Arg.Any<Audience>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Patch( Arg.Is<string>( uri => uri == "audience" ), Arg.Any<Audience>( ) );
        }
        
        [ Test ]
        public void Then_Valid_Audience_Is_Updated( )
        {
            MockBubbleClient
                .Received( )
                .Patch( Arg.Any<string>( ),
                    Arg.Is<Audience>(
                        x => x.AudienceAge.SequenceEqual( DefaultAudience.AudienceAge.Select( x => x.Id ) ) &&
                                    x.AudienceGender.SequenceEqual( DefaultAudience.AudienceGender.Select( x => x.Id ) ) &&
                                    x.AudienceLocation.SequenceEqual( DefaultAudience.AudienceLocation.Select( x => x.Id ) ) ) );
        }
    }
}
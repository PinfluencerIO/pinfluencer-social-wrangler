using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Audience = Pinf.InstaService.Core.Models.Audience;
using Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.Create.Shared
{
    public abstract class When_Called : Given_An_AudienceGenderRepository
    {
        protected AudienceGender DefaultAudienceGender =>
            new AudienceGender { Audience = "123", Id = "1", Name = "Male", Percentage = 0.5 };

        protected AudiencePercentage<GenderEnum> DefaultAudienceGenderModel =>
            new AudiencePercentage<GenderEnum> { Percentage = 0.5, Id = "1", Value = GenderEnum.Male, Audience = new Audience{ Id = "123" } };

        [ Test ]
        public void Then_Audience_Gender_Will_Be_Created_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Post( Arg.Any<string>( ), Arg.Any<AudienceGender>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Post( Arg.Is<string>( uri => uri == "audiencegender" ), Arg.Any<AudienceGender>( ) );
        }
        
        [ Test ]
        public void Then_Valid_Audience_Is_Updated( )
        {
            MockBubbleClient
                .Received( )
                .Post( Arg.Any<string>( ),
                    Arg.Is<AudienceGender>(
                        x => x.Audience == DefaultAudienceGender.Audience &&
                             x.Id == DefaultAudienceGender.Id && 
                             x.Name == DefaultAudienceGender.Name && 
                             x.Percentage.Equals( DefaultAudienceGender.Percentage ) ) );
        }
    }
}
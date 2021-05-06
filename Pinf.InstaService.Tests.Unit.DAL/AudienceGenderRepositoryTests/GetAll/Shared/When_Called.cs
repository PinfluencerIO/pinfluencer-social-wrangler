using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.GetAll.Shared
{
    public abstract class When_Called : Given_An_AudienceGenderRepository
    {
        [ Test ]
        public void Then_Audience_Will_Be_Updated_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Get<IEnumerable<AudienceGender>>( Arg.Any<string>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Get<IEnumerable<AudienceGender>>( Arg.Is<string>( uri => uri == "audiencegender" ) );
        }
    }
}
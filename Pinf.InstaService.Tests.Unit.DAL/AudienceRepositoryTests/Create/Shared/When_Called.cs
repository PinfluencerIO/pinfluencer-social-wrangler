using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using InfluencerModel = Pinf.InstaService.Core.Models.User.Influencer;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests.Create.Shared
{
    public abstract class When_Called : Given_An_AudienceRepository
    {
        [ Test ]
        public void Then_Audience_Will_Be_Created_Once( )
        {
            MockBubbleClient
                .Received( 1 )
                .Post( Arg.Any<string>( ), Arg.Any<Audience>( ) );
        }

        [ Test ]
        public void Then_Correct_Endpoint_Is_Reached( )
        {
            MockBubbleClient
                .Received( )
                .Post( Arg.Is<string>( uri => uri == "audience" ), Arg.Any<Audience>( ) );
        }
    }
}
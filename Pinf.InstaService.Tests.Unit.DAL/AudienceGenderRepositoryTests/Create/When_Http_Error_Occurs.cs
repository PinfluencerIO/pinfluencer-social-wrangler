using System.Net;
using NSubstitute;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.Create.Shared;
using Audience = Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble.Audience;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.Create
{
    public class When_Http_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            MockBubbleClient
                .Post( Arg.Any<string>( ), Arg.Any<AudienceGender>( ) )
                .Returns( HttpStatusCode.BadRequest );
            Result = Sut.Create( DefaultAudienceGenderModel );
        }
    }
}
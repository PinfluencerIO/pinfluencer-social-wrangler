using System.Net;
using NSubstitute;
using Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests.Update.Shared;
using Audience = Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble.Audience;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests.Update
{
    public class When_Http_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            MockBubbleClient
                .Post( Arg.Any<string>( ), Arg.Any<Audience>( ) )
                .Returns( HttpStatusCode.BadRequest );
            Result = Sut.Update( DefaultAudience );
        }
    }
}
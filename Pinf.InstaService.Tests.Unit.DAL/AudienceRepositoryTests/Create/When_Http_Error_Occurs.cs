using System.Net;
using NSubstitute;
using Pinf.InstaService.Core.Models;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests.Create.Shared;
using Audience = Pinf.InstaService.Core.Models.Audience;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceRepositoryTests.Create
{
    public class When_Http_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            MockBubbleClient
                .Post( Arg.Any<string>( ), Arg.Any<Influencer>( ) )
                .Returns( HttpStatusCode.BadRequest );
            Result = Sut.Create( new Audience( ) );
        }
    }
}
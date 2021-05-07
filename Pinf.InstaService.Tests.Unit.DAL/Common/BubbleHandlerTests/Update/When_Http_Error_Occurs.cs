using System.Net;
using NSubstitute;
using Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Update.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Update
{
    public class When_Http_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            MockBubbleClient
                .Patch( Arg.Any<string>( ), Arg.Any<TestDto>( ) )
                .Returns( HttpStatusCode.BadRequest );
            Result = SutCall( );
        }
    }
}
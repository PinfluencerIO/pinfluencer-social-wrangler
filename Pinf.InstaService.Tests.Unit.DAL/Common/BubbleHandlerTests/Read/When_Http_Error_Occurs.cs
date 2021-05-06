using System.Net;
using NSubstitute;
using Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Read.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.Common.BubbleHandlerTests.Read
{
    public class When_Http_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            MockBubbleClient
                .Get<TestDto>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.BadRequest, new TestDto( ) ) );
            Result = SutCall( );
        }
    }
}
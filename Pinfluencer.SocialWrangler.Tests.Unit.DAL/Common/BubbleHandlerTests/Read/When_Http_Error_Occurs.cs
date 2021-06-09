using System.Net;
using NSubstitute;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Read.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Read
{
    public class When_Http_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            MockBubbleClient
                .Get<Dto>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.BadRequest, new Dto( ) ) );
            Result = SutCall( );
        }
    }
}
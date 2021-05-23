using System.Net;
using NSubstitute;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Create.Shared;
using Audience = Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble.Audience;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Create
{
    public class When_Http_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            MockBubbleClient
                .Post( Arg.Any<string>( ), Arg.Any<Dto>( ) )
                .Returns( HttpStatusCode.BadRequest );
            Result = SutCall( );
        }
    }
}
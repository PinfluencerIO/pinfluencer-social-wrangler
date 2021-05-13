using System.Net;
using NSubstitute;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.UserRepositoryTests.Get
{
    public class When_Http_Error_Occurs : When_Bubble_Error_Occurs
    {
        protected override void When( )
        {
            MockBubbleClient
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.NotFound, new TypeResponse<Profile> { Type = new Profile( ) } ) );
            Result = Sut.Get( "1234" );
        }
    }
}
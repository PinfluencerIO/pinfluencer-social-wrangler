using System.Collections.Generic;
using System.Net;
using NSubstitute;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.GetAll.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.GetAll
{
    public class When_Http_Error_Occurs : When_Error_Occurs
    {
        protected override void When( )
        {
            MockBubbleClient
                .Get<IEnumerable<AudienceGender>>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.BadRequest, null ) );
            Result = Sut.GetAll( "123" );
        }
    }
}
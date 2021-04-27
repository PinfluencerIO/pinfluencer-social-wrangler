using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get
{
    public class When_Application_Error_Occurs : When_Error_Occurs
    { 
        protected override void When( )
        {
            MockBubbleClient
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.NotFound, new TypeResponse<Profile> { Type = new Profile() } ) );
            Result = Sut.Get( "1234" );
        }
    }
}
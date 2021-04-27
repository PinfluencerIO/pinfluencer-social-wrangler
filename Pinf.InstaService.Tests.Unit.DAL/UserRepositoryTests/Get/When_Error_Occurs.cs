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
    public class When_Error_Occurs : When_Called
    {
        private OperationResult<User> _result;

        protected override void When( )
        {
            MockBubbleClient
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.NotFound, new TypeResponse<Profile> { Type = new Profile() } ) );
            _result = Sut.Get( "1234" );
        }

        [ Test ]
        public void Then_Valid_User_Is_Be_Returned( )
        {
            Assert.True( _result.Value.Id == null && _result.Value.Name == null );
        }
        
        [ Test ]
        public void Then_Success_Is_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Failed, _result.Status );
        }
    }
}
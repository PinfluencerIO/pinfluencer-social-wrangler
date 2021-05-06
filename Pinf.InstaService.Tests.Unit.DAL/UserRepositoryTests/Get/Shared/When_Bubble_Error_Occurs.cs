using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get.Shared
{
    public abstract class When_Bubble_Error_Occurs : When_Facebook_Error_Does_Not_Occur
    {
        protected OperationResult<IUser> Result;

        [ Test ]
        public void Then_Empty_User_Is_Be_Returned( )
        {
            Assert.True( Result.Value.Id == null && Result.Value.Name == null );
        }

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }
        
        [ Test ]
        public void Then_Error_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogError( Arg.Any<string>( ) );
        }
    }
}
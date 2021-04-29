using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.User;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get.Shared
{
    public abstract class When_Error_Occurs : When_Called
    {
        protected OperationResult<IUser> Result;

        [ Test ]
        public void Then_Empty_User_Is_Be_Returned( )
        {
            Assert.True( Result.Value.Id == null && Result.Value.Name == null );
        }

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }
    }
}
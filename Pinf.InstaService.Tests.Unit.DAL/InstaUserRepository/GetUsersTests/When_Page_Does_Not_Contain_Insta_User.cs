using System.Collections.Generic;
using NUnit.Framework;
using Pinf.InstaService.BLL.Models.InstaUser;
using Pinf.InstaService.Bootstrapping.Services;
using Pinf.InstaService.Bootstrapping.Services.Enum;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaUserRepository.GetUsersTests
{
    public class When_Page_Does_Not_Contain_Insta_User : When_Get_Users_Is_Called
    {
        private OperationResult<IEnumerable<InstaUser>> _result;

        protected override void When()
        {
            SetEmptyPage();

            base.When();

            _result = Sut.GetUsers();
        }

        [Test]
        public void Then_The_Response_Is_Empty()
        {
            Assert.IsEmpty(_result.Value);
        }

        [Test]
        public void Then_The_Status_Is_Success()
        {
            Assert.AreEqual(OperationResultEnum.Success, _result.Status);
        }
    }
}
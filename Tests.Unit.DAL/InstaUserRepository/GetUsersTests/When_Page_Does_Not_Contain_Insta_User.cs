using System.Collections.Generic;
using BLL.Models.InstaUser;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using NUnit.Framework;

namespace Tests.Unit.DAL.InstaUserRepository.GetUsersTests
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
            Assert.AreEqual(OperationResultEnum.Success,_result.Status);
        }
    }
}
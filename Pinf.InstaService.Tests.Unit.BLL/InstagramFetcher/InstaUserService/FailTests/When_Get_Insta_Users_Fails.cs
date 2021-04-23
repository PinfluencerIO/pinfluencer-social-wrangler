using System.Linq;
using NUnit.Framework;
using Pinf.InstaService.BLL.Models.InstaUser;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstaUserService.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstaUserService.FailTests
{
    public class When_Get_Insta_Users_Fails : When_Get_All_Is_Called
    {
        private OperationResult<InstaUserIdentityCollection> _result;

        protected override void When()
        {
            InstaUserCollection = Enumerable.Empty<InstaUser>();
            InstaUsersOperationResult = OperationResultEnum.Failed;

            base.When();

            _result = Sut.GetAll();
        }

        [Test]
        public void Then_Operation_Result_Fails()
        {
            Assert.AreEqual(OperationResultEnum.Failed, _result.Status);
        }
    }
}
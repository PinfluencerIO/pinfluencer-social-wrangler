using System.Linq;
using BLL.Models.InstaUser;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using NUnit.Framework;
using Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.Shared;
using Tests.Unit.BLL.InstagramFetcher.InstaUserService.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.InstaUserService.FailTests
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
            Assert.AreEqual(OperationResultEnum.Failed,_result.Status);
        }
    }
}
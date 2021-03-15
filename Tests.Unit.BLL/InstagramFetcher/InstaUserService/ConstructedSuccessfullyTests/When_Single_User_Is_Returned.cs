using BLL.Models.InstaUser;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using NUnit.Framework;
using Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.Shared;
using Tests.Unit.BLL.InstagramFetcher.InstaUserService.Shared;
using System.Linq;

namespace Tests.Unit.BLL.InstagramFetcher.InstaUserService.ConstructedSuccessfullyTests
{
    public class When_Single_User_Is_Returned : When_Get_All_Is_Called
    {
        private OperationResult<InstaUserIdentityCollection> _result;

        protected override void When()
        {
            InstaUserCollection = new[]
                {new InstaUser(new InstaUserIdentity("example", "123213"), "Aidan Gannon", "this is my bio", 120)};
            InstaUsersOperationResult = OperationResultEnum.Success;

            base.When();

            _result = Sut.GetAll();
        }

        [Test]
        public void Then_Insta_User_Id_Was_Valid()
        {
            Assert.AreEqual("123213",_result.Value.InstaUserIdentities.First().Id);
        }
        
        [Test]
        public void Then_Insta_User_Handle_Was_Valid()
        {
            Assert.AreEqual("example",_result.Value.InstaUserIdentities.First().Handle);
        }
        
        [Test]
        public void Then_Has_Multiple_Was_False()
        {
            Assert.AreEqual(false,_result.Value.HasMultiple);
        }
        
        [Test]
        public void Then_Is_Empty_Was_False()
        {
            Assert.AreEqual(false,_result.Value.IsEmpty);
        }
    }
}
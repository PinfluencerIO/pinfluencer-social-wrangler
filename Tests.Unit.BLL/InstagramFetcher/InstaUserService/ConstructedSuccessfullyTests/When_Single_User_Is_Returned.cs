using BLL.Models.InstaUser;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using NUnit.Framework;
using Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.Shared;
using Tests.Unit.BLL.InstagramFetcher.InstaUserService.Shared;
using System.Linq;
using Tests.Unit.BLL.InstagramFetcher.InstaUserService.ConstructedSuccessfullyTests.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.InstaUserService.ConstructedSuccessfullyTests
{
    public class When_Single_User_Is_Returned : When_Constructed_Successfully
    {
        protected override void When()
        {
            SetSingleUser("example", "123213", "Aidan Gannon", "this is my bio", 120);

            base.When();

            Result = Sut.GetAll();
        }

        [Test]
        public void Then_Insta_User_Id_Was_Valid()
        {
            Assert.AreEqual("123213",Result.Value.InstaUserIdentities.First().Id);
        }
        
        [Test]
        public void Then_Insta_User_Handle_Was_Valid()
        {
            Assert.AreEqual("example",Result.Value.InstaUserIdentities.First().Handle);
        }
        
        [Test]
        public void Then_Has_Multiple_Was_False()
        {
            Assert.AreEqual(false,Result.Value.HasMultiple);
        }
        
        [Test]
        public void Then_Is_Empty_Was_False()
        {
            Assert.AreEqual(false,Result.Value.IsEmpty);
        }
    }
}
using System.Collections.Generic;
using BLL.Models.InstaUser;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Unit.BLL.InstagramFetcher.InstaUserService.Shared
{
    public abstract class When_Get_All_Is_Called : Given_A_InstaUserService
    {
        protected OperationResultEnum InstaUsersOperationResult { set; get; }
        protected IEnumerable<InstaUser> InstaUserCollection { set; get; }

        protected override void When()
        {
            MockInstaUserRepository
                .GetUsers()
                .Returns(new OperationResult<IEnumerable<InstaUser>>(
                    InstaUserCollection,
                    InstaUsersOperationResult
                ));
        }

        [Test]
        public void Then_Get_Insta_Users_Was_Called_Once()
        {
            MockInstaUserRepository
                .Received(1)
                .GetUsers();
        }
    }
}
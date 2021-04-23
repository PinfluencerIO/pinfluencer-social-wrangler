using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.BLL.Models.InstaUser;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Enum;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InstaUserService.Shared
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
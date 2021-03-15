using System.Collections;
using System.Collections.Generic;
using BLL.Models.InstaUser;
using Bootstrapping.Services.Enum;
using Tests.Unit.BLL.InstagramFetcher.InstaUserService.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.InstaUserService.ConstructedSuccessfullyTests.Shared
{
    public class When_Constructed_Successfully : When_Get_All_Is_Called
    {
        protected void SetSingleUser(string handle, string id, string name, string bio, int followers)
        {
            InstaUserCollection = new[]
                {new InstaUser(new InstaUserIdentity(handle, id), name, bio, followers)};
            InstaUsersOperationResult = OperationResultEnum.Success;
        }
        
        protected void SetTwoUsers(
            string handle1,
            string id1,
            string name1,
            string bio1,
            int followers1,
            string handle2,
            string id2,
            string name2,
            string bio2,
            int followers2
        )
        {
            InstaUserCollection = new[]
            {
                new InstaUser(new InstaUserIdentity(handle1, id1), name1, bio1, followers1),
                new InstaUser(new InstaUserIdentity(handle2, id2), name2, bio2, followers2)
            };
            InstaUsersOperationResult = OperationResultEnum.Success;
        }
    }
}
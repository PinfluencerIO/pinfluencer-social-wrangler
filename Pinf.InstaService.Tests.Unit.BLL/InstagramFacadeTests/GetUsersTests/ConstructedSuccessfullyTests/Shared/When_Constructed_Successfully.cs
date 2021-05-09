﻿using System.Collections.Generic;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Tests.Unit.BLL.InstagramFacadeTests.GetUsersTests.Shared;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFacadeTests.GetUsersTests.ConstructedSuccessfullyTests.Shared
{
    public abstract class When_Constructed_Successfully : When_Get_All_Is_Called
    {
        protected OperationResult<IEnumerable<InstaUser>> Result;

        protected void SetSingleUser( string handle, string id, string name, string bio, int followers )
        {
            InstaUserCollection = new [ ] 
            {
                new InstaUser
                {
                    Handle = handle,
                    Id = id,
                    Name = name,
                    Bio = bio,
                    Followers = followers
                } 
            };
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
            InstaUserCollection = new [ ]
            {
                new InstaUser
                {
                    Handle = handle1,
                    Id = id1,
                    Name = name1,
                    Bio = bio1,
                    Followers = followers1
                } ,
                new InstaUser
                {
                    Handle = handle2,
                    Id = id2,
                    Name = name2,
                    Bio = bio2,
                    Followers = followers2
                } 
            };
            InstaUsersOperationResult = OperationResultEnum.Success;
        }

        [ Test ]
        public void Then_Operation_Result_Was_Successful( )
        {
            Assert.AreEqual( OperationResultEnum.Success, Result.Status );
        }
    }
}
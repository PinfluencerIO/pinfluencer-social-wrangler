﻿using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Models.InstaUser;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;
using Crosscutting.CodeContracts;
using DAL.Instagram.Dtos;
using Newtonsoft.Json;
using InstaUser = BLL.Models.InstaUser.InstaUser;

namespace DAL.Instagram.Repositories
{
    public class FacebookInstaUserRepository : IInstaUserRepository
    {
        private FacebookContext _facebookContext;

        public FacebookInstaUserRepository(FacebookContext facebookContext)
        {
            _facebookContext = facebookContext;
        }

        public OperationResult<InstaUser> GetUser(string id)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult<IEnumerable<InstaUser>> GetUsers()
        { 
            var result = _facebookContext.Get("me/accounts",
            "instagram_business_account{id,username,name,biography,followers_count}");

            var dataArray = JsonConvert.DeserializeObject<DataArray<FacebookPage>>(result);

            new PostCondition().Evaluate(dataArray != null);

            if (dataArray == null) return null;
            var instaAccount = dataArray.Data.Select(x => x.Insta).First();
            return new OperationResult<IEnumerable<InstaUser>>(new []
            {
                new InstaUser(
                    new InstaUserIdentity(
                        instaAccount.Username,
                        instaAccount.Id
                    ),
                    instaAccount.Name,
                    instaAccount.Bio,
                    instaAccount.Followers
                )
            },OperationResultEnum.Success);
        }
    }
}
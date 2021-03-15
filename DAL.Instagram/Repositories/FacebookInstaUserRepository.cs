using System.Collections.Generic;
using BLL.Models.InstaUser;
using Bootstrapping.Services;
using Bootstrapping.Services.Repositories;

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
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using BLL.Models;
using Bootstrapping.Services.Repositories;

namespace DAL.Instagram.Repositories
{
    public class FacebookClientInstaUserRepository : IInstaUserRepository
    {
        public InstaUser GetUser(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<InstaUser> GetUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
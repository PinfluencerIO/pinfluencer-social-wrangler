using System.Collections.Generic;
using BLL.Models;

namespace Bootstrapping.Services.Repositories
{
    public interface IInstaUserRepository
    {
        InstaUser GetUser(string id);
        
        IEnumerable<InstaUser> GetUsers();
    }
}
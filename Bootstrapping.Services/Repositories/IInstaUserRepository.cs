using System.Collections.Generic;
using BLL.Models;

namespace Bootstrapping.Services.Repositories
{
    public interface IInstaUserRepository
    {
        QueryResult<InstaUser> GetUser(string id);
        
        QueryResult<IEnumerable<InstaUser>> GetUsers();
    }
}
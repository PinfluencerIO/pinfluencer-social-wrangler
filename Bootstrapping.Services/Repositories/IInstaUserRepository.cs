using System.Collections.Generic;
using BLL.Models;

namespace Bootstrapping.Services.Repositories
{
    public interface IInstaUserRepository
    {
        OperationResult<InstaUser> GetUser(string id);
        
        OperationResult<IEnumerable<InstaUser>> GetUsers();
    }
}
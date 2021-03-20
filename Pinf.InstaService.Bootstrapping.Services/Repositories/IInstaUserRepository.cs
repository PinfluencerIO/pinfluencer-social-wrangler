using System.Collections.Generic;
using Pinf.InstaService.BLL.Models.InstaUser;

namespace Pinf.InstaService.Bootstrapping.Services.Repositories
{
    public interface IInstaUserRepository
    {
        OperationResult<InstaUser> GetUser(string id);

        OperationResult<IEnumerable<InstaUser>> GetUsers();
    }
}
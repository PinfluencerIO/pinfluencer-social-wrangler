using System.Collections.Generic;
using Pinf.InstaService.Core.Models.InstaUser;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IInstaUserRepository
    {
        OperationResult<InstaUser> GetUser( string id );

        OperationResult<IEnumerable<InstaUser>> GetUsers( );
    }
}
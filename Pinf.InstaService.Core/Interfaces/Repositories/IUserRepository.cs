using Pinf.InstaService.Core.Dtos;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.User;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        OperationResult<string> GetInstagramToken( string auth0Id );
        OperationResultEnum CreateInfluencer( InfluencerProfile profile );
        OperationResult<User> Get( string id );
    }
}
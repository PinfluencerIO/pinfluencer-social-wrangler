using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.User;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        OperationResult<string> GetInstagramToken( string auth0Id );
        OperationResultEnum CreateInfluencer( Influencer influencer );
        OperationResult<IUser> Get( string id );
    }
}
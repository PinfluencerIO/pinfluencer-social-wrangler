using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        OperationResult<string> GetInstagramToken( string id );

        OperationResultEnum Create( string id );
    }
}
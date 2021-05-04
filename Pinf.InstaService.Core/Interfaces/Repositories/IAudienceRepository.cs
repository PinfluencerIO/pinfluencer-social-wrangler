using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IAudienceRepository
    {
        OperationResultEnum Create( Audience audience );
        
        OperationResultEnum Update( Audience audience );
    }
}
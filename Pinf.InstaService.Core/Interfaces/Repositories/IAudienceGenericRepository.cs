using System.Collections.Generic;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IAudienceGenericRepository<T>
    {
        OperationResult<IEnumerable<T>> GetAll( string audienceId );

        OperationResultEnum Create( T audience );
        
    }
}
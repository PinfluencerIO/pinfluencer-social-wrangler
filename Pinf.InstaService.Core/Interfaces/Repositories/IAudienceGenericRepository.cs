using System.Collections.Generic;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface IAudienceGenericRepository<T>
    {
        OperationResult<IEnumerable<AudiencePercentage<T>>> GetAll( string audienceId );

        OperationResultEnum Create( AudiencePercentage<T> audience );
    }
}
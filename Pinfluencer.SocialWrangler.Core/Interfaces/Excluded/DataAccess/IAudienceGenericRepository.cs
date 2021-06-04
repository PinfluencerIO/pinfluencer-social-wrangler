using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess
{
    public interface IAudienceGenericRepository<T>
    {
        OperationResult<IEnumerable<AudiencePercentage<T>>> GetAll( string audienceId );

        OperationResultEnum Create( AudiencePercentage<T> audience );
    }
}
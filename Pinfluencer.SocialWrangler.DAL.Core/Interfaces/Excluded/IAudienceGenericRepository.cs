using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface IAudienceGenericRepository<T>
    {
        OperationResult<IEnumerable<AudiencePercentage<T>>> GetAll( string audienceId );

        OperationResultEnum Create( AudiencePercentage<T> audience );
    }
}
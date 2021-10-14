using System.Collections.Generic;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface IAudienceGenericRepository<T>
    {
        ObjectResult<IEnumerable<AudiencePercentage<T>>> GetAll( string audienceId );

        OperationResultEnum Create( AudiencePercentage<T> audience );
    }
}
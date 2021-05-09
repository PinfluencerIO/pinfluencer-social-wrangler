using System.Collections.Generic;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceLocationRepository : IAudienceLocationRepository
    {
        public OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>> GetAll( string audienceId ) =>
            new OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>>(
                Enumerable.Empty<AudiencePercentage<LocationProperty>>( ), OperationResultEnum.Failed );

        public OperationResultEnum Create( AudiencePercentage<LocationProperty> audience ) =>
            OperationResultEnum.Failed;
    }
}
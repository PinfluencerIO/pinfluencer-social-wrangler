using System.Collections.Generic;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceAgeRepository : BubbleRepository<AudienceAgeRepository>, IAudienceAgeRepository
    {
        public AudienceAgeRepository( IBubbleClient bubbleClient, ILoggerAdapter<AudienceAgeRepository> logger ) : base( bubbleClient, logger )
        {
        }

        public OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAll( string audienceId ) =>
            new OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                Enumerable.Empty<AudiencePercentage<AgeProperty>>( ), OperationResultEnum.Failed );

        public OperationResultEnum Create( AudiencePercentage<AgeProperty> audience ) =>
            OperationResultEnum.Failed;
    }
}
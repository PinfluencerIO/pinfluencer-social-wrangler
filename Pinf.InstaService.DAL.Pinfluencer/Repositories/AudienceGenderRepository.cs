using System.Collections.Generic;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceGenderRepository : BubbleRepository<AudienceGenderRepository>, IAudienceGenderRepository
    {
        public AudienceGenderRepository( IBubbleClient bubbleClient, ILoggerAdapter<AudienceGenderRepository> logger ) : base( bubbleClient, logger )
        {
        }

        public OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAll( string audienceId )
        {
            return new OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>>( Enumerable.Empty<AudiencePercentage<GenderEnum>>( ),
                OperationResultEnum.Failed );
        }

        public OperationResultEnum Create( AudiencePercentage<GenderEnum> audience ) { throw new System.NotImplementedException( ); }
    }
}
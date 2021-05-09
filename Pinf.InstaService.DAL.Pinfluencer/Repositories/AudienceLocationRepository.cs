using System.Collections.Generic;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Core.Interfaces.Handlers;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceLocationRepository : IAudienceLocationRepository
    {
        private readonly IBubbleDataHandler<AudienceLocationRepository> _bubbleDataHandler;

        public AudienceLocationRepository( IBubbleDataHandler<AudienceLocationRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }
        
        public OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>> GetAll( string audienceId ) =>
            new OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>>(
                Enumerable.Empty<AudiencePercentage<LocationProperty>>( ), OperationResultEnum.Failed );

        public OperationResultEnum Create( AudiencePercentage<LocationProperty> audience ) =>
            OperationResultEnum.Failed;

        public AudienceLocation ModelMap( AudiencePercentage<LocationProperty> audienceLocation )
        {
            return new AudienceLocation( );
        }
    }
}
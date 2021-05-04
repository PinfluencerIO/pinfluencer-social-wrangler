using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceRepository : IAudienceRepository
    {
        private readonly IBubbleClient _bubbleClient;
        private readonly ILoggerAdapter<AudienceRepository> _logger;

        public AudienceRepository( IBubbleClient bubbleClient, ILoggerAdapter<AudienceRepository> logger )
        {
            _bubbleClient = bubbleClient;
            _logger = logger;
        }
        
        public OperationResultEnum Create( Audience audience )
        {
            return OperationResultEnum.Failed;
        }

        public OperationResultEnum Update( Audience audience )
        {
            throw new System.NotImplementedException( );
        }
    }
}
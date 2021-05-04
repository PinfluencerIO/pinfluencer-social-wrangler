using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceRepository : IAudienceRepository
    {
        private readonly IBubbleClient _bubbleClient;

        public AudienceRepository( IBubbleClient bubbleClient ) { _bubbleClient = bubbleClient; }
        
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
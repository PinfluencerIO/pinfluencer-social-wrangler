using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceRepository : BubbleRepository<AudienceRepository>, IAudienceRepository
    {
        protected override string Resource => "audience";
        
        public AudienceRepository( IBubbleClient bubbleClient, ILoggerAdapter<AudienceRepository> logger ) : base( bubbleClient, logger )
        {
        }
        
        public OperationResultEnum Create( AudienceModel audience ) => 
            BodiedNoResponseRequest( ( ) => BubbleClient.Post( Resource, new Audience( ) ), Resource );

        public OperationResultEnum Update( AudienceModel audience )
        {
            throw new System.NotImplementedException( );
        }
    }
}
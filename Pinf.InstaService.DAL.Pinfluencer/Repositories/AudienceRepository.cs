using System.Linq;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
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
            CreateRequest( ( ) => BubbleClient.Post( Resource, new Audience( ) ) );

        public OperationResultEnum Update( AudienceModel audience ) =>
            UpdateRequest( ( ) => BubbleClient.Patch( Resource, new Audience
            {
                AudienceAge = audience.AudienceAge.Select( x => x.Id ),
                AudienceGender = audience.AudienceGender.Select( x => x.Id ),
                AudienceLocation = audience.AudienceLocation.Select( x => x.Id )
            } ) );
    }
}
using System.Linq;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Core.Interfaces.Handlers;
using Pinf.InstaService.DAL.Pinfluencer.Common;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceRepository : IAudienceRepository
    {
        private const string Resource = "audience";
        
        private readonly IBubbleDataHandler<AudienceRepository> _bubbleDataHandler;
        public AudienceRepository( IBubbleDataHandler<AudienceRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public OperationResultEnum Create( AudienceModel audience ) => _bubbleDataHandler.Create( Resource, audience, EmptyModelMap );

        public OperationResultEnum Update( AudienceModel audience ) => _bubbleDataHandler.Update( Resource, audience, ModelMap );

        public Audience ModelMap( AudienceModel model ) =>
            new Audience
            {
                AudienceAge = model.AudienceAge.Select( x => x.Id ),
                AudienceGender = model.AudienceGender.Select( x => x.Id ),
                AudienceLocation = model.AudienceLocation.Select( x => x.Id )
            };

        public Audience EmptyModelMap( AudienceModel model ) => new Audience();
    }
}
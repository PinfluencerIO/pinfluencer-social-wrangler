using System.Linq;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Pinfluencer;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
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
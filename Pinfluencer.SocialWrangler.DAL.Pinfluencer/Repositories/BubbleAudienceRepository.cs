using System.Linq;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    public class BubbleAudienceRepository : IAudienceRepository
    {
        private const string Resource = "audience";

        private readonly IBubbleDataHandler<BubbleAudienceRepository> _bubbleDataHandler;

        public BubbleAudienceRepository( IBubbleDataHandler<BubbleAudienceRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public OperationResultEnum Create( AudienceModel audience )
        {
            return _bubbleDataHandler.Create( Resource, audience, EmptyModelMap );
        }

        public OperationResultEnum Update( AudienceModel audience )
        {
            return _bubbleDataHandler.Update( Resource, audience, ModelMap );
        }

        public Audience ModelMap( AudienceModel model )
        {
            return new Audience
            {
                AudienceAge = model.AudienceAge.Select( x => x.Id ),
                AudienceGender = model.AudienceGender.Select( x => x.Id ),
                AudienceLocation = model.AudienceLocation.Select( x => x.Id )
            };
        }

        public Audience EmptyModelMap( AudienceModel model ) { return new Audience( ); }
    }
}
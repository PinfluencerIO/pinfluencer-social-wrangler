using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.DL.Facades
{
    public class AudienceFacade
    {
        private readonly ISocialInsightUserFacade _socialInsightUserFacade;
        private readonly ISocialAudienceFacade _socialAudienceFacade;
        private readonly ISocialContentFacade _socialContentFacade;

        public AudienceFacade( ISocialAudienceFacade socialAudienceFacade,
            ISocialContentFacade socialContentFacade,
            ISocialInsightUserFacade socialInsightUserFacade )
        {
            _socialAudienceFacade = socialAudienceFacade;
            _socialContentFacade = socialContentFacade;
            _socialInsightUserFacade = socialInsightUserFacade;
        }
        
        public ObjectResult<Audience> GetFromSocial( )
        {
            return new ObjectResult<Audience>
            {
                Status = OperationResultEnum.Failed,
                Value = new Audience( )
            };
        }
    }
}
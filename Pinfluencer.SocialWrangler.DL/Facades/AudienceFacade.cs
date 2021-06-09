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
            var user = _socialInsightUserFacade
                .GetFirstUser( )
                .Value;
            return new ObjectResult<Audience>
            {
                Status = OperationResultEnum.Success,
                Value = new Audience
                {
                    AudienceAge = _socialAudienceFacade
                        .GetAudienceAgeInsights( user.Id )
                        .Value,
                    AudienceGender = _socialAudienceFacade
                        .GetAudienceGenderInsights( user.Id )
                        .Value,
                    AudienceCountry = _socialAudienceFacade
                        .GetAudienceCountryInsights( user.Id )
                        .Value,
                    EngagementRate = _socialContentFacade
                        .GetEngagementRate( )
                        .Value,
                    Followers = user.Followers,
                    Impressions = _socialContentFacade
                        .GetImpressions( user.Id )
                        .Value,
                    Reach = _socialContentFacade
                        .GetReach( user.Id )
                        .Value
                }
            };
        }
    }
}
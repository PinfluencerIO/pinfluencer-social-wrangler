using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.DL.Facades
{
    public class AudienceFacade : IAudienceFacade
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
            var userResult = _socialInsightUserFacade
                .GetFirstUser( );
            if( userResult.Status == OperationResultEnum.Failed )
            {
                return new ObjectResult<Audience>
                {
                    Status = OperationResultEnum.Failed,
                    Value = null
                };
            }

            var user = userResult.Value;

            var audienceAgeResult = _socialAudienceFacade
                .GetAudienceAgeInsights( user.Id );

            var audienceGenderResult = _socialAudienceFacade
                .GetAudienceGenderInsights( user.Id );

            var audienceCountryResult = _socialAudienceFacade
                .GetAudienceCountryInsights( user.Id );

            var engagementRateResult = _socialContentFacade
                .GetEngagementRate( );

            var impressionsResult = _socialContentFacade
                .GetImpressions( user.Id );

            var reachResult = _socialContentFacade
                .GetReach( user.Id );

            var warning = audienceAgeResult.Status == OperationResultEnum.Failed ||
                           audienceGenderResult.Status == OperationResultEnum.Failed ||
                           audienceCountryResult.Status == OperationResultEnum.Failed ||
                           engagementRateResult.Status == OperationResultEnum.Failed ||
                           impressionsResult.Status == OperationResultEnum.Failed ||
                           reachResult.Status == OperationResultEnum.Failed;

            return new ObjectResult<Audience>
            {
                Status = warning ? OperationResultEnum.Warning : OperationResultEnum.Success,
                Value = new Audience
                {
                    AudienceAge = audienceAgeResult.Status == OperationResultEnum.Success ?
                        audienceAgeResult.Value : Enumerable.Empty<AudiencePercentage<AgeProperty>>( ),
                    AudienceGender = audienceGenderResult.Status == OperationResultEnum.Success ?
                        audienceGenderResult.Value : Enumerable.Empty<AudiencePercentage<GenderEnum>>( ),
                    AudienceCountry = audienceCountryResult.Status == OperationResultEnum.Success ?
                        audienceCountryResult.Value : Enumerable.Empty<AudiencePercentage<CountryProperty>>( ),
                    EngagementRate = engagementRateResult.Status == OperationResultEnum.Success ?
                        engagementRateResult.Value : default,
                    Followers = user.Followers,
                    Impressions = impressionsResult.Status == OperationResultEnum.Success ?
                        impressionsResult.Value : default,
                    Reach = reachResult.Status == OperationResultEnum.Success ?
                        reachResult.Value : default,
                }
            };
        }
    }
}
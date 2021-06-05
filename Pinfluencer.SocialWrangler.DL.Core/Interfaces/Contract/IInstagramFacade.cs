using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface IInstagramFacade
    {
        OperationResult<IEnumerable<ContentImpressions>> GetMonthlyProfileViews( string id );
        OperationResult<IEnumerable<SocialInsightsUser>> GetUsers( );
        OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>> GetAudienceCountryInsights( string id );
        OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAudienceGenderInsights( string id );
        OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAudienceAgeInsights( string id );
    }
}
using System.Collections.Generic;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface ISocialAudienceFacade
    {
        ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>> GetAudienceCountryInsights(
            string id );

        ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAudienceGenderInsights( string id );
        ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAudienceAgeInsights( string id );
    }
}
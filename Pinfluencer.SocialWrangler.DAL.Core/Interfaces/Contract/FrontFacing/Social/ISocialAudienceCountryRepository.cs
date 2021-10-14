using System.Collections.Generic;
using Aidan.Common.Core;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface ISocialAudienceCountryRepository
    {
        ObjectResult<IEnumerable<AudienceCount<CountryProperty>>> Get( string instaId );
    }
}
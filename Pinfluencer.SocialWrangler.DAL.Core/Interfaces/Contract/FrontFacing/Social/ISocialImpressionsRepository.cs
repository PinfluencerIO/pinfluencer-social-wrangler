using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    //TODO: add time start and time end inputs
    public interface ISocialImpressionsRepository
    {
        ObjectResult<IEnumerable<ContentImpressions>> Get( string instaId );
    }
}
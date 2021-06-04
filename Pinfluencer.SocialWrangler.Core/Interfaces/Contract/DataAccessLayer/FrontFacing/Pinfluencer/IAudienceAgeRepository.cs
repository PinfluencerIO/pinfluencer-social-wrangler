using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess;
using Pinfluencer.SocialWrangler.Core.Models.Insights;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Pinfluencer
{
    public interface IAudienceAgeRepository : IAudienceGenericRepository<AgeProperty>
    {
    }
}
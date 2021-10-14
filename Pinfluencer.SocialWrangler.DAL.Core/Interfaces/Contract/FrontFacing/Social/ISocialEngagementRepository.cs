using Aidan.Common.Core;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social
{
    public interface ISocialEngagementRepository
    {
        ObjectResult<int> Get( string media );
    }
}
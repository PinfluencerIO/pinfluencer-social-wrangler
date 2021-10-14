using Aidan.Common.Core;

namespace Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract
{
    public interface ISocialContentFacade
    {
        ObjectResult<int> GetImpressions( string id );
        ObjectResult<int> GetReach( string id );
        ObjectResult<double> GetEngagementRate( );
    }
}
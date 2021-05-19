using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        OperationResult<string> GetInstagramToken( string auth0Id );
        OperationResultEnum CreateInfluencer( Influencer influencer );
        OperationResult<User> Get( string id );
    }
}
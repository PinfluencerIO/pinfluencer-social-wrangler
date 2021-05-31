using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        OperationResult<User> Get( string id );
    }
}
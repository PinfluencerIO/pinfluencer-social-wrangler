using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer
{
    public interface IUserRepository
    {
        OperationResult<User> Get( string id );
    }
}
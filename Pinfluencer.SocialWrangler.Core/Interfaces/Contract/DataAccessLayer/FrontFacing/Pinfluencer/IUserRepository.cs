using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Pinfluencer
{
    public interface IUserRepository
    {
        OperationResult<User> Get( string id );
    }
}
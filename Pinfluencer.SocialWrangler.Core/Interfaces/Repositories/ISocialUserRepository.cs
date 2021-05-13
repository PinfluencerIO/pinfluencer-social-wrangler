using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Models.InstaUser;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Repositories
{
    public interface ISocialUserRepository
    {
        OperationResult<InstaUser> Get( string id );

        OperationResult<IEnumerable<InstaUser>> GetAll( );
    }
}
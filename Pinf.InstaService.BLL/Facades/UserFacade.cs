using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;

namespace Pinf.InstaService.BLL.Facades
{
    public class UserFacade
    {
        private readonly IUserRepository _userRepository;

        public UserFacade( IUserRepository userRepository ) { _userRepository = userRepository; }
        
        public OperationResultEnum OnboardInfluencer( string id )
        {
            return OperationResultEnum.Failed;
        }
    }
}
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;

namespace Pinf.InstaService.BLL.Facades
{
    public class InfluencerFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly IInstaUserRepository _instaUserRepository;

        public InfluencerFacade( IUserRepository userRepository, IInstaUserRepository instaUserRepository )
        {
            _userRepository = userRepository;
            _instaUserRepository = instaUserRepository;
        }
        
        public OperationResultEnum OnboardInfluencer( string id )
        {
            return OperationResultEnum.Failed;
        }
    }
}
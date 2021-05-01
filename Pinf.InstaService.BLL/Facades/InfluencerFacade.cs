using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;

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
            var userResult = _userRepository.Get( id );
            if( userResult.Status != OperationResultEnum.Success )
            {
                return OperationResultEnum.Failed;
            }

            var user = userResult.Value;
            var instaUserResult = _instaUserRepository.GetAll(  );
            if( instaUserResult.Status != OperationResultEnum.Success )
            {
                return OperationResultEnum.Failed;
            }
            
            var instaUser = instaUserResult.Value.First( );
            _userRepository.CreateInfluencer( new Influencer
            {
                Age = user.Age,
                Bio = instaUser.Bio,
                Gender = user.Gender,
                InstagramHandle = instaUser.Handle,
                Location = user.Location,
                User = user
            } );
            return OperationResultEnum.Success;
        }
    }
}
using System.Linq;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;

namespace Pinf.InstaService.BLL.Facades
{
    public class InfluencerFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly ISocialUserRepository _socialUserRepository;

        public InfluencerFacade( IUserRepository userRepository, ISocialUserRepository socialUserRepository )
        {
            _userRepository = userRepository;
            _socialUserRepository = socialUserRepository;
        }
        
        public OperationResultEnum OnboardInfluencer( string id )
        {
            var userResult = _userRepository.Get( id );
            if( userResult.Status != OperationResultEnum.Success )
            {
                return OperationResultEnum.Failed;
            }

            var user = userResult.Value;
            var instaUserResult = _socialUserRepository.GetAll(  );
            if( instaUserResult.Status != OperationResultEnum.Success )
            {
                return OperationResultEnum.Failed;
            }
            
            var instaUsers = instaUserResult.Value;
            if( !instaUsers.Any() )
            {
                return OperationResultEnum.Failed;
            }

            var instaUser = instaUsers.First( );
            var influnecerStatus = _userRepository.CreateInfluencer( new Influencer
            {
                Age = user.Age,
                Bio = instaUser.Bio,
                Gender = user.Gender,
                InstagramHandle = instaUser.Handle,
                Location = user.Location,
                User = user
            } );
            return influnecerStatus;
        }
    }
}
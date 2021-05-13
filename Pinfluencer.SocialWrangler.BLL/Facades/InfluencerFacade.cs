using System.Linq;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.BLL.Facades
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
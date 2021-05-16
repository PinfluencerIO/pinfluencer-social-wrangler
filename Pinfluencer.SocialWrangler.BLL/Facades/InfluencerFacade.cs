using System.Linq;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.BLL.Facades
{
    public class InfluencerFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly IInsightsSocialUserRepository _insightsSocialUserRepository;

        public InfluencerFacade( IUserRepository userRepository, IInsightsSocialUserRepository insightsSocialUserRepository )
        {
            _userRepository = userRepository;
            _insightsSocialUserRepository = insightsSocialUserRepository;
        }
        
        public OperationResultEnum OnboardInfluencer( string id )
        {
            var userResult = _userRepository.Get( id );
            if( userResult.Status != OperationResultEnum.Success )
            {
                return OperationResultEnum.Failed;
            }

            var user = userResult.Value;
            var instaUserResult = _insightsSocialUserRepository.GetAll(  );
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
                InstagramHandle = instaUser.Username,
                Location = user.Location,
                User = user
            } );
            return influnecerStatus;
        }
    }
}
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
        private readonly IInfluencerRepository _influencerRepository;

        public InfluencerFacade( IUserRepository userRepository, IInsightsSocialUserRepository insightsSocialUserRepository, IInfluencerRepository influencerRepository )
        {
            _userRepository = userRepository;
            _insightsSocialUserRepository = insightsSocialUserRepository;
            _influencerRepository = influencerRepository;
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
            
            //TODO: get social info user and put into influencer
            
                var influnecerStatus = _influencerRepository.Create( new Influencer
                {
                    Bio = instaUser.Bio,
                    InstagramHandle = instaUser.Username,
                    User = user
                } );
                return influnecerStatus;
        }
    }
}
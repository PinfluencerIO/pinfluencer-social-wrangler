using System.Linq;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.User;

namespace Pinfluencer.SocialWrangler.BLL.Facades
{
    public class InfluencerFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly ISocialInfoUserRepository _socialInfoUserRepository;
        private readonly IInsightsSocialUserRepository _insightsSocialUserRepository;
        private readonly IInfluencerRepository _influencerRepository;

        public InfluencerFacade( IUserRepository userRepository, IInsightsSocialUserRepository insightsSocialUserRepository, IInfluencerRepository influencerRepository, ISocialInfoUserRepository socialInfoUserRepository )
        {
            _userRepository = userRepository;
            _insightsSocialUserRepository = insightsSocialUserRepository;
            _influencerRepository = influencerRepository;
            _socialInfoUserRepository = socialInfoUserRepository;
        }
        
        public OperationResultEnum OnboardInfluencer( string id )
        {
            var userResult = _userRepository.Get( id );
            if( userResult.Status != OperationResultEnum.Success )
            {
                return OperationResultEnum.Failed;
            }

            var user = userResult.Value;
            var socialInsightUserResult = _insightsSocialUserRepository.GetAll(  );
            if( socialInsightUserResult.Status != OperationResultEnum.Success )
            {
                return OperationResultEnum.Failed;
            }
            
            var socialInsightUsers = socialInsightUserResult.Value;
            if( !socialInsightUsers.Any() )
            {
                return OperationResultEnum.Failed;
            }

            var socialInsightsUser = socialInsightUsers.First( );

            var socialInfoUserResult = _socialInfoUserRepository.Get( );
            if( socialInfoUserResult.Status == OperationResultEnum.Failed )
            {
                return OperationResultEnum.Failed;
            }
            
            var socialInfoUser = socialInfoUserResult.Value;

            var influnecerStatus = _influencerRepository.Create( new Influencer
            {
                Bio = socialInsightsUser.Bio,
                SocialUsername = socialInsightsUser.Username,
                User = user,
                Age = socialInfoUser.Age,
                Gender = socialInfoUser.Gender,
                Location = socialInfoUser.Location.Country
            } );
            return influnecerStatus;
        }
    }
}
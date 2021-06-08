using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;

namespace Pinfluencer.SocialWrangler.DL.Commands
{
    public class GetInfluencerFromSocialCommand
    {
        private readonly IInsightsSocialUserRepository _insightsSocialUserRepository;
        private readonly ISocialInfoUserRepository _socialInfoUserRepository;
        
        public GetInfluencerFromSocialCommand( ISocialInfoUserRepository socialInfoUserRepository,
            IInsightsSocialUserRepository insightsSocialUserRepository )
        {
            _socialInfoUserRepository = socialInfoUserRepository;
            _insightsSocialUserRepository = insightsSocialUserRepository;
        }

        public ObjectResult<Influencer> Run( )
        {
            var failResult = new ObjectResult<Influencer>
            {
                Status = OperationResultEnum.Failed,
                Value = null
            };
            var socialInsightUserResult = _insightsSocialUserRepository.GetAll( );
            if( socialInsightUserResult.Status != OperationResultEnum.Success ) return failResult;

            var socialInsightUsers = socialInsightUserResult.Value;
            if( !socialInsightUsers.Any( ) ) return failResult;

            var socialInsightsUser = socialInsightUsers.First( );

            var socialInfoUserResult = _socialInfoUserRepository.Get( );
            if( socialInfoUserResult.Status == OperationResultEnum.Failed ) return failResult;

            var socialInfoUser = socialInfoUserResult.Value;

            return new ObjectResult<Influencer>
            {
                Status = OperationResultEnum.Success,
                Value = new Influencer
                {
                    Bio = socialInsightsUser.Bio,
                    SocialUsername = socialInsightsUser.Username,
                    Age = socialInfoUser.Age,
                    Gender = socialInfoUser.Gender,
                    Location = socialInfoUser.Location
                }
            };
        }
    }
}
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
            return new ObjectResult<Influencer>
            {
                Status = OperationResultEnum.Failed,
                Value = null
            };
        }
    }
}
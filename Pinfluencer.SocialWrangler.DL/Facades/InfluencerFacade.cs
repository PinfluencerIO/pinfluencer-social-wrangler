using System.Linq;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.DL.Facades
{
    public class InfluencerFacade : IInfluencerFacade
    {
        private readonly IInfluencerRepository _influencerRepository;
        private readonly IGetInfluencerFromSocialCommand _getInfluencerFromSocialCommand;
        private readonly IUserRepository _userRepository;

        public InfluencerFacade( IUserRepository userRepository,
            IInfluencerRepository influencerRepository,
            IGetInfluencerFromSocialCommand getInfluencerFromSocialCommand )
        {
            _userRepository = userRepository;
            _influencerRepository = influencerRepository;
            _getInfluencerFromSocialCommand = getInfluencerFromSocialCommand;
        }

        public OperationResultEnum Onboard( string id )
        {
            var userResult = _userRepository.Get( id );
            if( userResult.Status != OperationResultEnum.Success ) return OperationResultEnum.Failed;

            /*var influnecerStatus = _influencerRepository.Create( new Influencer
            {
                Bio = socialInsightsUser.Bio,
                SocialUsername = socialInsightsUser.Username,
                User = user,
                Age = socialInfoUser.Age,
                Gender = socialInfoUser.Gender,
                Location = socialInfoUser.Location
            } );*/
            return OperationResultEnum.Failed;
        }
    }
}
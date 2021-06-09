using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer;
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

            var influencerFromSocialResult = _getInfluencerFromSocialCommand
                .Run( );
            if( influencerFromSocialResult.Status == OperationResultEnum.Failed )
            {
                return OperationResultEnum.Failed;
            }

            var influencerFromSocial = influencerFromSocialResult.Value;
            influencerFromSocial
                .User = userResult.Value;
            
            var influnecerStatus = _influencerRepository.Create( influencerFromSocial );
            return influnecerStatus;
        }
    }
}
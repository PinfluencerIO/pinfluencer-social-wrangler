using Facebook;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Managers
{
    public class FacebookAuthManager : ISocialAuthManager
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IFacebookDecorator _facebookDecorator;

        public FacebookAuthManager( ITokenRepository tokenRepository, IFacebookDecorator facebookDecorator )
        {
            _tokenRepository = tokenRepository;
            _facebookDecorator = facebookDecorator;
        }

        //TODO: override default message
        public Result Initialize( string authUser )
        {
            var tokenResult = _tokenRepository.Get( authUser );
            if( tokenResult.Status == OperationResultEnum.Failed )
            {
                return Result.Error( "auth0 id did not match an existing user" );
            }
            _facebookDecorator.Token = tokenResult.Value;
            try
            {
                _facebookDecorator.Get<object>( "debug_token",
                    new RequestDebugTokenParams { input_token = tokenResult.Value } );
            }
            catch( FacebookApiException e )
            {
                return Result.Error( e.Message );
            }
            return Result.Success( );
        }
    }
}
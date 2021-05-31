using System;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    public class FacebookTokenRepository : ITokenRepository
    {
        private readonly Auth0Context _auth0Context;
        private readonly ILoggerAdapter<FacebookTokenRepository> _logger;
        public FacebookTokenRepository( ILoggerAdapter<FacebookTokenRepository> logger, Auth0Context auth0Context )
        {
            _logger = logger;
            _auth0Context = auth0Context;
        }

        public OperationResult<string> Get( string authId )
        {
            try
            {
                var user = _auth0Context.GetUser( authId );
                var result =
                    new OperationResult<string>( user.Identities[ 0 ].AccessToken, OperationResultEnum.Success );
                _logger.LogInfo( "instagram token fetched successfully" );
                return result;
            }
            catch( Exception )
            {
                _logger.LogError( "instagram token was not fetched" );
                return new OperationResult<string>( "", OperationResultEnum.Failed );
            }
        }
    }
}
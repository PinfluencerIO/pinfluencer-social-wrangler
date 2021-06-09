using System;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class Auth0FacebookTokenRepository : IFacebookTokenRepository
    {
        private readonly IAuthServiceManagementClientDecorator _auth0ManagementClientDecorator;
        private readonly ILoggerAdapter<Auth0FacebookTokenRepository> _logger;

        public Auth0FacebookTokenRepository( ILoggerAdapter<Auth0FacebookTokenRepository> logger, IAuthServiceManagementClientDecorator auth0ManagementClientDecorator )
        {
            _logger = logger;
            _auth0ManagementClientDecorator = auth0ManagementClientDecorator;
        }

        public ObjectResult<string> Get( string authId )
        {
            try
            {
                var token = _auth0ManagementClientDecorator.GetIdentityToken( authId );
                var result =
                    new ObjectResult<string>( token, OperationResultEnum.Success );
                _logger.LogInfo( "instagram token fetched successfully" );
                return result;
            }
            catch( Exception )
            {
                _logger.LogError( "instagram token was not fetched" );
                return new ObjectResult<string>( "", OperationResultEnum.Failed );
            }
        }
    }
}
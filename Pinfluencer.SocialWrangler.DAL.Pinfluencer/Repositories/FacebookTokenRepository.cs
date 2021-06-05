using System;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    public class FacebookTokenRepository : ITokenRepository
    {
        private readonly IAuthServiceManagementClientDecorator _auth0ManagementClientDecorator;
        private readonly ILoggerAdapter<FacebookTokenRepository> _logger;

        public FacebookTokenRepository( ILoggerAdapter<FacebookTokenRepository> logger, IAuthServiceManagementClientDecorator auth0ManagementClientDecorator )
        {
            _logger = logger;
            _auth0ManagementClientDecorator = auth0ManagementClientDecorator;
        }

        public OperationResult<string> Get( string authId )
        {
            try
            {
                var token = _auth0ManagementClientDecorator.GetIdentityToken( authId );
                var result =
                    new OperationResult<string>( token, OperationResultEnum.Success );
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
using System;
using Facebook;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.DAL.Common.Handlers
{
    public class FacebookDataHandler<T> : IFacebookDataHandler<T> where T : class
    {
        private readonly IFacebookDecorator _facebookClient;
        private readonly ILoggerAdapter<T> _logger;
        public FacebookDataHandler( IFacebookDecorator facebookClient, ILoggerAdapter<T> logger )
        {
            _facebookClient = facebookClient;
            _logger = logger;
        }

        public OperationResult<TModel> Read<TModel, TDto>( string resource, Func<TDto, TModel> mapper,
            TModel defaultModel, object optionalParams = null )
        {
            var ( result, fbResult ) = validateFacebookCall( ( ) => _facebookClient.Get<TDto>( resource, optionalParams ) );
            if( !fbResult )
            {
                _logger.LogError( $"{nameof( TModel )} were not fetched" );
                return new OperationResult<TModel>
                {
                    Value = defaultModel,
                    Status = OperationResultEnum.Failed,
                    Msg = $"{nameof( TModel )} were not fetched"
                };
            }
            else
            {
                _logger.LogInfo( $"{nameof( TModel )} were fetched" );
                return new OperationResult<TModel>( mapper( result ), OperationResultEnum.Success );
            }
        }
            
        
        private( T, bool ) validateFacebookCall<T>( Func<T> facebookCall )
        {
            var errorReturn = ( default( T ), false );
            try { return( facebookCall( ), true ); }
            catch( FacebookApiLimitException )
            {
                _logger.LogError( "facebook api limit error occured" );
            }
            catch( FacebookOAuthException )
            {
                _logger.LogError( "facebook oauth error occured" );
            }
            catch( FacebookApiException e )
            {
                _logger.LogError( "facebook api error occured" );
                _logger.LogError( e.Message );
            }
            return errorReturn;;
        }
            
    }
}
using System;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using Aidan.Common.Core.Interfaces.Contract;
using Facebook;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;

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

        public ObjectResult<TModel> Read<TModel, TDto>( string resource, Func<TDto, TModel> mapper,
            TModel defaultModel, object optionalParams = null )
        {
            var (result, fbResult) =
                validateFacebookCall( ( ) => _facebookClient.Get<TDto>( resource, optionalParams ) );
            if( !fbResult )
            {
                _logger.LogError( $"{nameof( TModel )} were not fetched" );
                return new ObjectResult<TModel>
                {
                    Value = defaultModel,
                    Status = OperationResultEnum.Failed,
                    Msg = $"{nameof( TModel )} were not fetched"
                };
            }

            _logger.LogInfo( $"{nameof( TModel )} were fetched" );
            return new ObjectResult<TModel>( mapper( result ), OperationResultEnum.Success );
        }


        private( T, bool ) validateFacebookCall<T>( Func<T> facebookCall )
        {
            var errorReturn = ( default( T ), false );
            try { return( facebookCall( ), true ); }
            catch( FacebookApiLimitException ) { _logger.LogError( "facebook api limit error occured" ); }
            catch( FacebookOAuthException ) { _logger.LogError( "facebook oauth error occured" ); }
            catch( FacebookApiException e )
            {
                _logger.LogError( "facebook api error occured" );
                _logger.LogError( e.Message );
            }

            return errorReturn;
        }
    }
}
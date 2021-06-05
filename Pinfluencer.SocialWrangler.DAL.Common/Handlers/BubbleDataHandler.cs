using System;
using System.Net;
using System.Net.Http;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;

namespace Pinfluencer.SocialWrangler.DAL.Common.Handlers
{
    public class BubbleDataHandler<T> : IBubbleDataHandler<T> where T : class
    {
        private readonly IBubbleClient _bubbleClient;
        private readonly ILoggerAdapter<T> _logger;

        public BubbleDataHandler( IBubbleClient bubbleClient, ILoggerAdapter<T> logger )
        {
            _bubbleClient = bubbleClient;
            _logger = logger;
        }

        public OperationResultEnum Create<TModel, TDto>( string uri, TModel model, Func<TModel, TDto> mapper )
        {
            return bodiedNoResponseRequest<TModel>( ( ) => _bubbleClient.Post( uri, mapper( model ) ), "created" );
        }

        public OperationResult<TModel> Read<TModel, TDto>( string uri, Func<TDto, TModel> mapper, TModel defaultModel,
            object optionalParams = null )
        {
            return nonBodiedResponseRequest( ( ) => _bubbleClient.Get<TDto>( uri ), mapper, "fetched", defaultModel );
        }

        public OperationResultEnum Update<TModel, TDto>( string uri, TModel model, Func<TModel, TDto> mapper )
        {
            return bodiedNoResponseRequest<TModel>( ( ) => _bubbleClient.Patch( uri, mapper( model ) ), "updated" );
        }

        private static bool validateHttpCode( HttpStatusCode code )
        {
            return code
                .GetHashCode( )
                .ToString( )[ 0 ]
                .ToString( ) == "2";
        }

        private static( bool, T ) validateRequestException<T>( Func<T> httpFunc )
        {
            try { return( true, httpFunc( ) ); }
            catch( Exception e ) when( e is ArgumentException || e is HttpRequestException )
            {
                return( false, default );
            }
        }

        private OperationResultEnum bodiedNoResponseRequest<T>( Func<HttpStatusCode> call, string action )
        {
            var (validRequest, httpStatusCode) =
                validateRequestException( call );
            if( validRequest )
                if( validateHttpCode( httpStatusCode ) )
                {
                    _logger.LogInfo( $"{nameof( T )} was {action} successfully" );
                    return OperationResultEnum.Success;
                }

            _logger.LogError( $"{nameof( T )} was not {action}" );
            return OperationResultEnum.Failed;
        }

        private OperationResult<TModel> nonBodiedResponseRequest<TModel, TDataDto>(
            Func<( HttpStatusCode, TDataDto )> call,
            Func<TDataDto, TModel> mapper,
            string action,
            TModel defaultModel )
        {
            var (validRequest, (httpStatusCode, response)) =
                validateRequestException( call );
            if( validRequest )
                if( validateHttpCode( httpStatusCode ) )
                {
                    _logger.LogInfo( $"{typeof( TModel )} was {action} successfully" );
                    return new OperationResult<TModel>( mapper( response ), OperationResultEnum.Success );
                }

            _logger.LogError( $"{typeof( TModel )} was not {action}" );
            return new OperationResult<TModel>( defaultModel, OperationResultEnum.Failed );
        }
    }
}
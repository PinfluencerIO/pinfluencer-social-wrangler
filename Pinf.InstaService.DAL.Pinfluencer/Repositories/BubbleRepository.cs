using System;
using System.Net;
using System.Net.Http;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public abstract class BubbleRepository<TRepo> where TRepo : class
    {
        protected readonly IBubbleClient BubbleClient;
        protected readonly ILoggerAdapter<TRepo> Logger;
        protected virtual string Resource => default;

        protected BubbleRepository( IBubbleClient bubbleClient, ILoggerAdapter<TRepo> logger )
        {
            BubbleClient = bubbleClient;
            Logger = logger;
        }
        
        protected bool ValidateHttpCode( HttpStatusCode code ) { return code.GetHashCode( ).ToString( )[0].ToString() == "2"; }

        protected( bool, T ) ValidateRequestException<T>( Func<T> httpFunc )
        {
            try { return( true, httpFunc( ) ); }
            catch( Exception e ) when( e is ArgumentException || e is HttpRequestException )
            {
                return( false, default );
            }
        }

        protected OperationResultEnum BodiedNoResponseRequest( Func<HttpStatusCode> call, string action )
        {
            var (validRequest, httpStatusCode ) =
                ValidateRequestException( call );
            if( validRequest )
                if( ValidateHttpCode( httpStatusCode ) )
                {
                    Logger.LogInfo( $"{Resource} was {action} successfully" );
                    return OperationResultEnum.Success;
                }
            Logger.LogError( $"{Resource} was not {action}" );
            return OperationResultEnum.Failed;
        }

        protected OperationResult<TModel> NonBodiedResponseRequest<TModel, TDataDto>( Func<( HttpStatusCode, TDataDto )> call,
            Func<TDataDto, TModel> mapper,
            string action,
            TModel defaultModel )
        {
            var (validRequest, ( httpStatusCode, response ) ) =
                ValidateRequestException( call );
            if( validRequest )
                if( ValidateHttpCode( httpStatusCode ) )
                {
                    Logger.LogInfo( $"{Resource} was {action} successfully" );
                    return new OperationResult<TModel>( mapper( response ), OperationResultEnum.Success );
                }
            Logger.LogError( $"{Resource} was not {action}" );
            return new OperationResult<TModel>( defaultModel, OperationResultEnum.Failed );
        }

        protected OperationResultEnum CreateRequest( Func<HttpStatusCode> call ) =>
            BodiedNoResponseRequest( call, "created" );

        protected OperationResultEnum UpdateRequest( Func<HttpStatusCode> call ) =>
            BodiedNoResponseRequest( call, "updated" );
        
        protected OperationResult<TModel> GetRequest<TModel, TDto>( Func<( HttpStatusCode, TDto )> call,
            Func<TDto, TModel> mapper,
            TModel defaultModel ) =>
            NonBodiedResponseRequest( call, mapper, "fetched", defaultModel );
    }
}
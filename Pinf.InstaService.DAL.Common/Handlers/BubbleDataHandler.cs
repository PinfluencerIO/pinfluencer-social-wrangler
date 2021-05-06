using System;
using System.Net;
using System.Net.Http;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Core.Interfaces.Handlers;

namespace Pinf.InstaService.DAL.Common.Handlers
{
    public class BubbleDataHandler : IBubbleDataHandler
    {
        private readonly IBubbleClient _bubbleClient;
        private readonly ILoggerAdapter<BubbleDataHandler> _logger;

        public BubbleDataHandler( IBubbleClient bubbleClient, ILoggerAdapter<BubbleDataHandler> logger )
        {
            _bubbleClient = bubbleClient;
            _logger = logger;
        }

        public OperationResultEnum Create<TModel>( string uri, TModel body )
        {
            throw new NotImplementedException( );
        }

        public OperationResult<TModel> Read<TModel, TDataDto>( string uri, Func<TDataDto, TModel> mapper,
            TModel defaultModel )
        {
            throw new NotImplementedException( );
        }

        public OperationResultEnum Update<TModel>( string uri, TModel body )
        {
            throw new NotImplementedException( );
        }
    }
}
using System;
using System.Net;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.DAL.Core.Interfaces.Handlers
{
    public interface IBubbleDataHandler<T>
    {
        OperationResultEnum Create<TModel, TDto>( string uri, TModel model, Func<TModel, TDto> mapper );

        OperationResult<TModel> Read<TModel, TDto>( string uri,
            Func<TDto, TModel> mapper,
            TModel defaultModel );

        OperationResultEnum Update<TModel, TDto>( string uri, TModel model, Func<TModel, TDto> mapper );
    }
}
﻿using System;
using System.Net;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.DAL.Core.Interfaces.Handlers
{
    public interface IBubbleDataHandler
    {
        OperationResultEnum Create<TModel, TDto>( string uri, TModel model, Func<TModel, TDto> mapper );

        OperationResult<TModel> Read<TModel, TDataDto>( string uri,
            Func<TDataDto, TModel> mapper,
            TModel defaultModel );

        OperationResultEnum Update<TModel>( string uri, TModel body );
    }
}
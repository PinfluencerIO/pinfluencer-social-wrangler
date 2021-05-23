using System;
using Pinfluencer.SocialWrangler.Core;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IReadable
    {
        OperationResult<TModel> Read<TModel, TDto>( string resource,
            Func<TDto, TModel> mapper,
            TModel defaultModel,
            object defaultParams = null );
    }
}
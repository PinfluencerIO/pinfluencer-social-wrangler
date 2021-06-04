using System;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess
{
    public interface IReadable
    {
        OperationResult<TModel> Read<TModel, TDto>( string resource,
            Func<TDto, TModel> mapper,
            TModel defaultModel,
            object defaultParams = null );
    }
}
using System;
using Aidan.Common.Core;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface IReadable
    {
        ObjectResult<TModel> Read<TModel, TDto>( string resource,
            Func<TDto, TModel> mapper,
            TModel defaultModel,
            object defaultParams = null );
    }
}
using System;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IUpdatable
    {
        OperationResultEnum Update<TModel, TDto>( string resource, TModel model, Func<TModel, TDto> mapper );
    }
}
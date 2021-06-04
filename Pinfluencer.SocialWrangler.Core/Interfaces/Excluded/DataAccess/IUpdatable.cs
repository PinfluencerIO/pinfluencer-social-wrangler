using System;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess
{
    public interface IUpdatable
    {
        OperationResultEnum Update<TModel, TDto>( string resource, TModel model, Func<TModel, TDto> mapper );
    }
}
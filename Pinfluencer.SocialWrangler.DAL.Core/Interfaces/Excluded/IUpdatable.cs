using System;
using Aidan.Common.Core.Enum;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface IUpdatable
    {
        OperationResultEnum Update<TModel, TDto>( string resource, TModel model, Func<TModel, TDto> mapper );
    }
}
using System;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface ICreateable
    {
        OperationResultEnum Create<TModel, TDto>( string resource, TModel model, Func<TModel, TDto> mapper );
    }
}
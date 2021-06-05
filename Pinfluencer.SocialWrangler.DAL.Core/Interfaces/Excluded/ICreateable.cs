using System;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface ICreateable
    {
        OperationResultEnum Create<TModel, TDto>( string resource, TModel model, Func<TModel, TDto> mapper );
    }
}
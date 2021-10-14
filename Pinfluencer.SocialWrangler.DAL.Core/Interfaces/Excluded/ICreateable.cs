using System;
using Aidan.Common.Core.Enum;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface ICreateable
    {
        OperationResultEnum Create<TModel, TDto>( string resource, TModel model, Func<TModel, TDto> mapper );
    }
}